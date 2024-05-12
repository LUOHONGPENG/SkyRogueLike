using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public GameData gameData;
    public BattleManager battleManager;
    public UIManager uiManager;

    public override void Init()
    {
        ExcelDataManager.Instance.Init();
        gameData = new GameData();
        battleManager.Init();
        uiManager.Init();

        StartBattle(1);
    }

    public void StartBattle(int levelID)
    {
        battleManager.BattleStart(levelID);
    }
}
