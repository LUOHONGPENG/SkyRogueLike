using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleViewManager : MonoBehaviour
{
    [Header("Character")]
    public CharacterView characterView;

    [Header("Monster")]
    public Transform tfMonsterView;
    public GameObject pfMonsterView;
    public List<Transform> listFixedMonsterPos = new List<Transform>();

    private List<MonsterView> listMonsterView = new List<MonsterView>();
    private Dictionary<int, MonsterView> dicMonsterView = new Dictionary<int, MonsterView>();

    public void ClearMonster()
    {
        PublicTool.ClearChildItem(tfMonsterView);
        dicMonsterView.Clear();
    }

    /// <summary>
    /// 假定这个只有在战斗开始时候调用
    /// </summary>
    public void GenerateMonsterView(BattleMonsterData monsterData)
    {
        int posID = listMonsterView.Count;
        GameObject objMonster = GameObject.Instantiate(pfMonsterView, tfMonsterView);
        MonsterView itemMonster = objMonster.GetComponent<MonsterView>();
        itemMonster.Init(monsterData);

        itemMonster.transform.position = listFixedMonsterPos[posID].position;
        listMonsterView.Add(itemMonster);
        dicMonsterView.Add(posID, itemMonster);
    }
}
