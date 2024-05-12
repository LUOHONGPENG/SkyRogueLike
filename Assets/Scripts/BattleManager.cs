using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.U2D.Animation;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public BattleViewManager battleViewManager;

    [HideInInspector]
    public BattleData battleData;

    public void Init()
    {
        TypeEventSystem.Global.Register<UseCardMonsterRequest>(e => {
            DealCardActionRequest(e.cardID,e.monsterPosID);
        }).UnRegisterWhenGameObjectDestroyed(gameObject);

    }

    public void BattleStart(int levelID)
    {
        LevelExcelItem levelExcelItem = ExcelDataManager.Instance.levelConfig.GetLevelExcelItem(levelID);
        battleData = new BattleData(PublicTool.GetGameData().characterData);
        battleViewManager.characterView.Init(PublicTool.GetGameData().characterData);//Init Character View

        //Generate Monster 
        battleViewManager.ClearMonster();
        for(int i = 0; i < levelExcelItem.listMonsterID.Length; i++)
        {
            GenerateMonster(levelExcelItem.listMonsterID[i]);
        }

        TypeEventSystem.Global.Send(new BattleStartRequest());
        CharacterTurnStart();
    }

    public void GenerateMonster(int excelID)
    {
        BattleMonsterData monsterData = battleData.AddMonsterData(excelID);
        battleViewManager.GenerateMonsterView(monsterData);
    }

    public void CharacterTurnStart()
    {
        TypeEventSystem.Global.Send(new TurnStartDrawCardRequset());

    }

    public void MonsterTurnStart()
    {

    }


    #region DealAction

    public void DealCardActionRequest(int cardID,int monsterPosID)
    {
        CardExcelItem cardExcelItem = ExcelDataManager.Instance.cardConfig.GetCardExcelItem(cardID);

        List<BattleActionInfo> listActionInfo = cardExcelItem.listActionInfo;
        DealCardAction(listActionInfo, monsterPosID);
    }

    public void DealCardAction(List<BattleActionInfo> listActionInfo,int targetID)
    {
        for(int i = 0; i < listActionInfo.Count; i++)
        {
            BattleActionInfo actionInfo = listActionInfo[i];
            switch (actionInfo.actionEffect)
            {
                case BasicActionEffect.Attack:
                    CharacterAttackAction(actionInfo, targetID);
                    break;
            }
        }
    }

    public void DealMonsterAction(List<BattleActionInfo> listActionInfo, int monsterID)
    {
        for (int i = 0; i < listActionInfo.Count; i++)
        {
            BattleActionInfo actionInfo = listActionInfo[i];
            switch (actionInfo.actionEffect)
            {
                case BasicActionEffect.Attack:
                    MonsterAttackAction(actionInfo, monsterID);
                    break;
            }
        }
    }

    #endregion

    #region AttackDeal

    private void CharacterAttackAction(BattleActionInfo actionInfo, int monsterID)
    {
        for(int i = 0; i < actionInfo.actionTime; i++)
        {
            switch (actionInfo.actionRange)
            {
                case BasicActionRange.Self:
                    battleData.battleCharacterData.GetHurt(actionInfo.actionValue);
                    break;
                case BasicActionRange.Single:
                    battleData.GetTargetBattleMonster(monsterID).GetHurt(actionInfo.actionValue);
                    break;
                case BasicActionRange.Group:
                    for(int j = 0;j< battleData.listMonsterData.Count; j++)
                    {
                        battleData.listMonsterData[j].GetHurt(actionInfo.actionValue);

                    }
                    break;
            }
        }
    }

    private void MonsterAttackAction(BattleActionInfo actionInfo, int selfID)
    {
        for (int i = 0; i < actionInfo.actionTime; i++)
        {
            switch (actionInfo.actionRange)
            {
                case BasicActionRange.Self:
                    battleData.GetTargetBattleMonster(selfID).GetHurt(actionInfo.actionValue);
                    break;
                case BasicActionRange.Single:
                case BasicActionRange.Group:
                    battleData.battleCharacterData.GetHurt(actionInfo.actionValue);
                    break;
            }
        }
    }

    #endregion



}
