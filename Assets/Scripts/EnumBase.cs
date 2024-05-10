using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BasicActionEffect
{
    Attack,
    Block,
    Heal,
    Buff,//debuff
    Debuff,
    Special
}

public enum BasicActionRange
{
    Self,
    Single,
    Group
}


public enum MonsterAction
{
    SingleAttack,
    AttackBlock,
    SelfBlock,
    GroupBlock,
    SelfHeal,
    SelfBuff
}

public enum BattleUnitType
{
    None,
    Character,
    Monster

}

