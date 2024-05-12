using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterView : MonoBehaviour
{
    public SpriteRenderer spMonster;
    private int excelID = -1;

    public void Init(BattleMonsterData monsterData)
    {
        excelID = monsterData.excelID;
        MonsterExcelItem excelData = ExcelDataManager.Instance.monsterConfig.GetMonsterExcelItem(excelID);
        spMonster.sprite = Resources.Load("Sprite/" + excelData.iconUrl, typeof(Sprite)) as Sprite;
    }
}
