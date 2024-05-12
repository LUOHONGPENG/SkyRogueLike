using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private List<int> listCardID_all = new List<int>();

    private List<int> listCardID_stack = new List<int>();
    private List<int> listCardID_hand = new List<int>();
    private List<int> listCardID_used = new List<int>();


    public Transform tfCard;
    public GameObject pfCard;

    public int canDrawNum = 4;

    private GameData gameData;

    public void Init()
    {
        gameData = PublicTool.GetGameData();

        TypeEventSystem.Global.Register<BattleStartRequest>(e => {
            BattleStartDeal();
        }).UnRegisterWhenGameObjectDestroyed(gameObject);

        TypeEventSystem.Global.Register<TurnStartDrawCardRequset>(e => {
            TurnStartDrawCard();
        }).UnRegisterWhenGameObjectDestroyed(gameObject);
    }

    public void BattleStartDeal()
    {
        listCardID_all = new List<int>(gameData.listCardID);
        listCardID_stack = new List<int>(listCardID_all);
    }

    public void TurnStartDrawCard()
    {
        if (canDrawNum <= listCardID_stack.Count)
        {
            listCardID_hand = PublicTool.DrawNum(canDrawNum, listCardID_stack, listCardID_used);
            for(int i = 0; i < listCardID_hand.Count; i++)
            {
                listCardID_stack.Remove(listCardID_hand[i]);
            }
        }
        else
        {
            //Draw all to Hard
            listCardID_hand = new List<int>(listCardID_stack);
            listCardID_stack.Clear();
            MoveUsedCardToStack();
            int needDraw =   (canDrawNum - listCardID_hand.Count);
            needDraw = needDraw <= listCardID_stack.Count ? needDraw : listCardID_stack.Count;
            List<int> twiceDraw = PublicTool.DrawNum(needDraw, listCardID_stack, listCardID_hand);
            for(int i = 0; i < twiceDraw.Count; i++)
            {
                listCardID_hand.Add(twiceDraw[i]);
            }
        }
        ShowHandCardView();
    }

    public void MoveUsedCardToStack()
    {
        listCardID_stack = new List<int>(listCardID_used);
        listCardID_used.Clear();
    }


    #region View 

    public void ShowHandCardView()
    {
        for(int i = 0; i < listCardID_hand.Count; i++)
        {
            int thisCardID = listCardID_hand[i];
            GameObject objCard = GameObject.Instantiate(pfCard, tfCard);
            CardView itemCard = objCard.GetComponent<CardView>();
            itemCard.Init(thisCardID,this);
        }
    }

    public void UseCard(CardView card,Vector2 pos)
    {
        CardExcelItem excelItem = ExcelDataManager.Instance.cardConfig.GetCardExcelItem(card.cardID);

        if (excelItem.targetEnemy)
        {
            Ray ray = Camera.main.ScreenPointToRay(pos);
            RaycastHit2D[] hits = Physics2D.RaycastAll(ray.origin, ray.direction, 100f, 1 << LayerMask.NameToLayer("Monster"));
            for(int i = 0; i < hits.Length; i++)
            {
                RaycastHit2D hit = hits[i];
                Debug.Log(hit.transform?.gameObject.name);
                if (hit.collider != null && hit.collider.transform.parent.GetComponent<MonsterView>() != null)
                {
                    int monsterPosID = hit.collider.transform.parent.GetComponent<MonsterView>().posID;
                    TypeEventSystem.Global.Send(new UseCardMonsterRequest(excelItem.id, monsterPosID));
                    Destroy(card.gameObject);
                    Debug.Log("UseCard");
                    break;
                }
            }
        }
        else
        {


        }

    }
    #endregion
}
