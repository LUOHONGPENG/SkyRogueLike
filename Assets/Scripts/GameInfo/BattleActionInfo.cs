using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleActionInfo
{
    public BasicActionEffect actionEffect;
    public BasicActionRange actionRange;
    public int actionValue;
    public int actionTime;

    public BattleActionInfo(BasicActionEffect actionEffect, BasicActionRange actionRange, int actionValue,int actionTime = 1)
    {
        this.actionEffect = actionEffect;
        this.actionRange = actionRange;
        this.actionValue = actionValue;
        this.actionTime = actionTime;
    }
}
