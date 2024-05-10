using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicTool
{
    public static int TranslateMonsterActionToID(MonsterAction monsterActionName)
    {
        return ExcelDataManager.Instance.monsterActionConfig.TranslateMonsterActionID(monsterActionName);
    }

}
