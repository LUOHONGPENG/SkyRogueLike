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
        Debug.Log(111);
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

    public void UseCard()
    {
        Debug.Log("UseCard ");
    }
    #endregion
}
