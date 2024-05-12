using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BattleStartRequest { }
public struct TurnStartDrawCardRequset { }

public struct UseCardMonsterRequest
{
    public int cardID;
    public int monsterPosID;

    public UseCardMonsterRequest(int cardID, int monsterPosID)
    {
        this.cardID = cardID;
        this.monsterPosID = monsterPosID;
    }
}