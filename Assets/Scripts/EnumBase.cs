using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BasicActionEffect
{
    None,
    Attack,
    Block,
    Heal,
    Buff,//debuff
    Debuff,
    Special
}

public enum BasicActionRange
{
    None,
    Self,
    Single,
    Group
}


public enum MonsterAction
{
    None,
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

