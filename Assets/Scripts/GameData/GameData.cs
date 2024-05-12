using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData
{
    public BattleCharacterData characterData;

    public List<int> listCardID = new List<int>();


    /// <summary>
    /// GameStart
    /// </summary>
    public GameData()
    {
        characterData = new BattleCharacterData();
        InitCard();
        Debug.Log("InitGameData");
    }

    public void InitCard()
    {
        listCardID.Clear();

        for(int i = 0; i < 5; i++)
        {
            listCardID.Add(1001);
        }
        listCardID.Add(1002);
        listCardID.Add(1003);

    }
}
