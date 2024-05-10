using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public partial class MonsterActionExcelData
{
    private Dictionary<MonsterAction, int> dicMonsterActionEnum = new Dictionary<MonsterAction, int>();

    public void InitExtra()
    {
        dicMonsterActionEnum.Clear();

        for (int i = 0; i < items.Length; i++)
        {
            MonsterActionExcelItem item = items[i];
            if (!dicMonsterActionEnum.ContainsKey(item.monsterActionName))
            {
                dicMonsterActionEnum.Add(item.monsterActionName, item.id);
            }
        }
    }

    public int TranslateMonsterActionID(MonsterAction monsterActionName)
    {
        if (dicMonsterActionEnum.ContainsKey(monsterActionName))
        {
            return dicMonsterActionEnum[monsterActionName];
        }
        return -1;
    }




}
