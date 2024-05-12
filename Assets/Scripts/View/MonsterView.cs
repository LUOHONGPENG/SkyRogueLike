using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MonsterView : MonoBehaviour
{
    public SpriteRenderer spMonster;

    public Image imgHPfill;
    public TextMeshProUGUI txHP;


    private int excelID = -1;
    public int posID = -1;
    private BattleMonsterData monsterData;
    private bool isInit = false;

    public void Init(BattleMonsterData monsterData,int posID)
    {
        this.monsterData = monsterData;
        excelID = monsterData.excelID;
        this.posID = posID;
        MonsterExcelItem excelData = ExcelDataManager.Instance.monsterConfig.GetMonsterExcelItem(excelID);
        spMonster.sprite = Resources.Load("Sprite/" + excelData.iconUrl, typeof(Sprite)) as Sprite;

        isInit = true;
    }

    private void Update()
    {
        if (!isInit) return;
        if (monsterData != null)
        {
            imgHPfill.fillAmount = monsterData.HPrate;
            txHP.text = string.Format("{0}/{1}", monsterData.curHP, monsterData.maxHP);
        }
    }

    public int GetKeyID()
    {
        return monsterData.keyID;
    }
}
