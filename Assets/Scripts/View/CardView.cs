using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardView : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    private CardManager cardManager;
    public CanvasGroup canvasGroupThis;
    public TextMeshProUGUI txName;
    public TextMeshProUGUI txDesc;

    public int cardID = -1;

    public void Init(int cardID,CardManager parent)
    {
        this.cardID = cardID;
        this.cardManager = parent;

        CardExcelItem cardItem = ExcelDataManager.Instance.cardConfig.GetCardExcelItem(cardID);
        txName.text = cardItem.name;
        txDesc.text = cardItem.desc;
    }

    private Vector2 pointerOffset;
    private Vector2 initPos;
    private bool isInitPos = false;

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            transform.position = eventData.position - pointerOffset;
        }
    }

    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (!isInitPos)
            {
                initPos = transform.position;
            }
            pointerOffset = Vector2.zero;
            canvasGroupThis.blocksRaycasts = false;
            //TypeEventSystem.Global.Send(new PropUIPointerDownInput(excelID, propIndex));
        }
    }

    void IPointerUpHandler.OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Vector2 pointerPos = eventData.position;
            if (!EventSystem.current.IsPointerOverGameObject())
            {
                cardManager.UseCard(this, pointerPos);
                //TypeEventSystem.Global.Send(new PropUIDragDropInput(propIndex, pointerPos));
            }
            canvasGroupThis.blocksRaycasts = true;
            this.transform.DOMove(initPos, 0.5F);
        }
    }
}
