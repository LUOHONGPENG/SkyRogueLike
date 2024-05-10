using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleUnitData//Battle unit common data
{
    public BattleUnitType battleUnitType;

    public bool isDead = false;

    #region HPATK
    public int curHP;//Current HP
    public int maxHP;//Max HP

    public float HPrate
    {
        get
        {
            return 1.0f * curHP / maxHP;
        }
    }
    #endregion

    #region Battle

    public int GetHurt(int damage)
    {
        int totalDamage = Mathf.Abs(damage);
        int loseShield = LoseShield(totalDamage);
        totalDamage -= loseShield;
        if (totalDamage > 0)
        {
            int loseHPValue = LoseHP(totalDamage);
            return loseHPValue;
        }
        return 0;
    }


    public int LoseHP(int damage)
    {
        curHP -= Mathf.Abs(damage);
        if (curHP <= 0)
        {
            curHP = 0;
            isDead = true;
        }
        return damage;
    }

    public void RecoverHP(int value)
    {
        curHP += value;
        if (curHP > maxHP)
        {
            curHP = maxHP;
        }
    }
    #endregion

    #region Shield

    public int curShield;

    public int LoseShield(int damage)
    {
        int tempBeforeShield = curShield;
        curShield -= Mathf.Abs(damage);
        if (curShield <= 0)
        {
            curShield = 0;
        }
        return tempBeforeShield - curShield;//lose Shield
    }

    #endregion
}
