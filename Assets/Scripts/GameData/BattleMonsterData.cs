using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterData : BattleUnitData
{
    int excelID = -1;
    private MonsterExcelItem excelItem;

    public BattleMonsterData(int excelID)
    {
        excelItem = ExcelDataManager.Instance.monsterConfig.GetMonsterExcelItem(excelID);
        maxHP = excelItem.maxHP;
        curHP = maxHP;

    }
}
