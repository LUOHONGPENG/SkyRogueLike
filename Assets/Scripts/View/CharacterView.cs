using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    public Image imgHPfill;
    public TextMeshProUGUI txHP;

    private BattleCharacterData curCharacterData;
    private bool isInit = false;

    public void Init(BattleCharacterData characterData)
    {
        curCharacterData = characterData;
        isInit = true;
    }


    private void Update()
    {
        if (!isInit) return;
        if (curCharacterData != null)
        {
            imgHPfill.fillAmount = curCharacterData.HPrate;
            txHP.text = string.Format("{0}/{1}", curCharacterData.curHP, curCharacterData.maxHP);
        }
    }

}
