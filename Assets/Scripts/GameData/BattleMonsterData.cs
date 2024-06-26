using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMonsterData : BattleUnitData
{
    public int excelID = -1;
    public int keyID = -1;

    private MonsterExcelItem excelItem;

    public BattleMonsterData(int excelID)
    {
        this.excelID = excelID;
        excelItem = ExcelDataManager.Instance.monsterConfig.GetMonsterExcelItem(excelID);
        maxHP = excelItem.maxHP;
        curHP = maxHP;

    }

    public void SetKeyID(int keyID)
    {
        this.keyID = keyID;
    }
}
