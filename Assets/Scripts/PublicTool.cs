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

    public static int GetRandomIndexIntArray(int[] array)
    {
        int totalWeight = 0;
        //Sum up
        for (int i = 0; i < array.Length; i++)
        {
            totalWeight += array[i];
        }

        //Calculate
        if (totalWeight > 0)
        {
            int ran = Random.Range(0, totalWeight);
            for (int i = 0; i < array.Length; i++)
            {
                ran -= array[i];
                if (ran < 0)
                {
                    return i;
                }
            }
        }
        return -1;
    }

    public static List<int> DrawNum(int num, List<int> listPool, List<int> listDelete)
    {
        List<int> listTemp = new List<int>();
        List<int> listDraw = new List<int>(listPool);
        if (listDelete != null)
        {
            for (int i = 0; i < listDelete.Count; i++)
            {
                listDraw.Remove(listDelete[i]);
            }
        }

        for (int i = 0; i < num; i++)
        {
            int index = Random.Range(0, listDraw.Count);
            listTemp.Add(listDraw[index]);
            listDraw.RemoveAt(index);
        }
        return listTemp;
    }
}
