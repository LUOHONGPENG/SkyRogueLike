using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleViewManager : MonoBehaviour
{
    [Header("Character")]
    public CharacterView characterView;

    [Header("Monster")]
    public Transform tfMonsterView;
    public List<Transform> listFixedMonsterPos = new List<Transform>();
}
