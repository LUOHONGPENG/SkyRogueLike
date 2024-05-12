using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleData
{
    //Data
    public BattleCharacterData battleCharacterData;
    public Dictionary<int, BattleMonsterData> dicMonsterData = new Dictionary<int, BattleMonsterData>();
    public List<BattleMonsterData> listMonsterData = new List<BattleMonsterData>();

    private int monsterKeyID = 0;

    public BattleMonsterData GetTargetBattleMonster(int keyID)
    {
        if (dicMonsterData.ContainsKey(keyID))
        {
            return dicMonsterData[keyID];
        }
        return null;
    }

    public BattleData(BattleCharacterData characterData)
    {
        battleCharacterData = characterData;
/*        battleCharacterData.curHP = characterData.curHP;
        battleCharacterData.maxHP = characterData.maxHP;*/
    }

    public BattleMonsterData AddMonsterData(int excelID)
    {
        BattleMonsterData monsterData = new BattleMonsterData(excelID);

        dicMonsterData.Add(monsterKeyID, monsterData);
        listMonsterData.Add(monsterData);
        monsterData.SetKeyID(monsterKeyID);
        monsterKeyID++;

        return monsterData;
    }
}
