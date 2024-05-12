using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicTool
{
    public static GameData GetGameData()
    {
        return GameManager.instance.gameData;
    }

    public static int TranslateMonsterActionToID(MonsterAction monsterActionName)
    {
        return ExcelDataManager.Instance.monsterActionConfig.TranslateMonsterActionID(monsterActionName);
    }
    public static void ClearChildItem(UnityEngine.Transform tf)
    {
        foreach (UnityEngine.Transform item in tf)
        {
            UnityEngine.Object.Destroy(item.gameObject);
        }
    }
}
