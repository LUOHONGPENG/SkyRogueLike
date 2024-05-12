using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public GameData gameData;
    public BattleManager battleManager;

    private void Start()
    {
        Init();
    }

    public override void Init()
    {
        gameData = new GameData();
        battleManager.Init();

        StartBattle(1);
    }

    public void StartBattle(int levelID)
    {
        battleManager.BattleStart(levelID);
    }
}
