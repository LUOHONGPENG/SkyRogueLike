using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class MonsterExcelItem
{


    public List<BattleActionInfo> GetRandomActionInfo()
    {
        int actionNum = 0;
        if(actionType_0!= MonsterAction.None)
        {
            actionNum++;
        }
        if (actionType_1 != MonsterAction.None)
        {
            actionNum++;
        }
        if (actionType_2 != MonsterAction.None)
        {
            actionNum++;
        }

        int curActionID = UnityEngine.Random.Range(0, actionNum);

        switch (curActionID)
        {
            case 0:
                return GetListActionInfo_0();
            case 1:
                return GetListActionInfo_1();
            case 2:
                return GetListActionInfo_2();
        }
        return null;

    }



    //随机行动0
    public List<BattleActionInfo> GetListActionInfo_0()
    {
        List<BattleActionInfo> tempActionInfo = new List<BattleActionInfo>();
        //MonsterAction
        int monsterActionID = PublicTool.TranslateMonsterActionToID(actionType_0);
        MonsterActionExcelItem monsterActionExcelData = ExcelDataManager.Instance.monsterActionConfig.GetMonsterActionExcelItem(monsterActionID);

        if (monsterActionExcelData.actionEffect_0 != BasicActionEffect.None)
        {
            tempActionInfo.Add(new BattleActionInfo(monsterActionExcelData.actionEffect_0, monsterActionExcelData.actionRange_0, actionValue_0[0], actionTime_0[0]));
        }

        if (monsterActionExcelData.actionEffect_1 != BasicActionEffect.None)
        {
            tempActionInfo.Add(new BattleActionInfo(monsterActionExcelData.actionEffect_1, monsterActionExcelData.actionRange_1, actionValue_0[1], actionTime_0[1]));
        }

        return tempActionInfo;
    }

    //随机行动1
    public List<BattleActionInfo> GetListActionInfo_1()
    {
        List<BattleActionInfo> tempActionInfo = new List<BattleActionInfo>();
        //MonsterAction
        int monsterActionID = PublicTool.TranslateMonsterActionToID(actionType_1);
        MonsterActionExcelItem monsterActionExcelData = ExcelDataManager.Instance.monsterActionConfig.GetMonsterActionExcelItem(monsterActionID);

        if (monsterActionExcelData.actionEffect_0 != BasicActionEffect.None)
        {
            tempActionInfo.Add(new BattleActionInfo(monsterActionExcelData.actionEffect_0, monsterActionExcelData.actionRange_0, actionValue_1[0], actionTime_1[0]));
        }

        if (monsterActionExcelData.actionEffect_1 != BasicActionEffect.None)
        {
            tempActionInfo.Add(new BattleActionInfo(monsterActionExcelData.actionEffect_1, monsterActionExcelData.actionRange_1, actionValue_1[1], actionTime_1[1]));
        }

        return tempActionInfo;
    }

    //随机行动2
    public List<BattleActionInfo> GetListActionInfo_2()
    {
        List<BattleActionInfo> tempActionInfo = new List<BattleActionInfo>();
        //MonsterAction
        int monsterActionID = PublicTool.TranslateMonsterActionToID(actionType_2);
        MonsterActionExcelItem monsterActionExcelData = ExcelDataManager.Instance.monsterActionConfig.GetMonsterActionExcelItem(monsterActionID);

        if (monsterActionExcelData.actionEffect_0 != BasicActionEffect.None)
        {
            tempActionInfo.Add(new BattleActionInfo(monsterActionExcelData.actionEffect_0, monsterActionExcelData.actionRange_0, actionValue_2[0], actionTime_2[0]));
        }

        if (monsterActionExcelData.actionEffect_1 != BasicActionEffect.None)
        {
            tempActionInfo.Add(new BattleActionInfo(monsterActionExcelData.actionEffect_1, monsterActionExcelData.actionRange_1, actionValue_2[1], actionTime_2[1]));
        }

        return tempActionInfo;
    }
}
