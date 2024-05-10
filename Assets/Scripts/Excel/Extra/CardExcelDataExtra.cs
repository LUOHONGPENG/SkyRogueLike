using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class CardExcelItem
{
    //卡片效果列表
    public List<BattleActionInfo> listActionInfo
    {
        get 
        {
            List<BattleActionInfo> tempActionInfo = new List<BattleActionInfo>();
            if(actionEffect_0 != BasicActionEffect.None)
            {
                tempActionInfo.Add(new BattleActionInfo(actionEffect_0, actionRange_0, actionValue_0, actionTime_0));
            }

            if (actionEffect_1 != BasicActionEffect.None)
            {
                tempActionInfo.Add(new BattleActionInfo(actionEffect_1, actionRange_1, actionValue_1, actionTime_1));
            }

            if (actionEffect_2 != BasicActionEffect.None)
            {
                tempActionInfo.Add(new BattleActionInfo(actionEffect_2, actionRange_2, actionValue_2, actionTime_2));
            }

            return tempActionInfo;
        }
    }
}
