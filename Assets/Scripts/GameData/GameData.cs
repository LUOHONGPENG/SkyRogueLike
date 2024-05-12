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
        listCardID.Clear();
        Debug.Log("InitGameData");
    }
}
