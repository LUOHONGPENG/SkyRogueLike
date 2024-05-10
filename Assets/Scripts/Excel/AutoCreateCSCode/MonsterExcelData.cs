/*Auto Create, Don't Edit !!!*/

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public partial class MonsterExcelItem : ExcelItemBase
{
	/// <summary>
	/// 怪物id
	/// </summary>>
	public int id;
	/// <summary>
	/// 名称
	/// </summary>>
	public string monsterName;
	/// <summary>
	/// 生命值
	/// </summary>>
	public float maxHP;
	/// <summary>
	/// 行动1
	/// </summary>>
	public MonsterAction actionType_1;
	/// <summary>
	/// 行动1数值
	/// </summary>>
	public int[] actionValue_1;
	/// <summary>
	/// 行动2
	/// </summary>>
	public MonsterAction actionType_2;
	/// <summary>
	/// 行动2数值
	/// </summary>>
	public int[] actionValue_2;
	/// <summary>
	/// 行动3
	/// </summary>>
	public MonsterAction actionType_3;
	/// <summary>
	/// 行动3数值
	/// </summary>>
	public int[] actionValue_3;
}


public partial class MonsterExcelData : ExcelDataBase<MonsterExcelItem>
{
	public MonsterExcelItem[] items;

	public Dictionary<int,MonsterExcelItem> itemDic = new Dictionary<int,MonsterExcelItem>();

	public void Init()
	{
		itemDic.Clear();
		if(items != null && items.Length > 0)
		{
			for(int i = 0; i < items.Length; i++)
			{
				itemDic.Add(items[i].id, items[i]);
			}
		}
	}

	public MonsterExcelItem GetMonsterExcelItem(int id)
	{
		if(itemDic.ContainsKey(id))
			return itemDic[id];
		else
			return null;
	}
	#region --- Get Method ---

	public string GetMonsterName(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.monsterName;
	}

	public float GetMaxHP(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.maxHP;
	}

	public MonsterAction GetActionType_1(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionType_1;
	}

	public int[] GetActionValue_1(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionValue_1;
	}
	public int GetActionValue_1(int id, int index)
	{
		var item0 = GetMonsterExcelItem (id);
		if(item0 == null)
			return default;
		var item1 = item0.actionValue_1;
		if(item1 == null || index < 0 || index >= item1.Length)
			return default;
		return item1[index];
	}

	public MonsterAction GetActionType_2(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionType_2;
	}

	public int[] GetActionValue_2(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionValue_2;
	}
	public int GetActionValue_2(int id, int index)
	{
		var item0 = GetMonsterExcelItem (id);
		if(item0 == null)
			return default;
		var item1 = item0.actionValue_2;
		if(item1 == null || index < 0 || index >= item1.Length)
			return default;
		return item1[index];
	}

	public MonsterAction GetActionType_3(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionType_3;
	}

	public int[] GetActionValue_3(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionValue_3;
	}
	public int GetActionValue_3(int id, int index)
	{
		var item0 = GetMonsterExcelItem (id);
		if(item0 == null)
			return default;
		var item1 = item0.actionValue_3;
		if(item1 == null || index < 0 || index >= item1.Length)
			return default;
		return item1[index];
	}

	#endregion
}


#if UNITY_EDITOR
public class MonsterAssetAssignment
{
	public static bool CreateAsset(ExcelMediumData excelMediumData, string excelAssetPath)
	{
		var allRowItemDicList = excelMediumData.GetAllRowItemDicList();
		if(allRowItemDicList == null || allRowItemDicList.Count == 0)
			return false;

		int rowCount = allRowItemDicList.Count;
		MonsterExcelData excelDataAsset = ScriptableObject.CreateInstance<MonsterExcelData>();
		excelDataAsset.items = new MonsterExcelItem[rowCount];

		for(int i = 0; i < rowCount; i++)
		{
			var itemRowDic = allRowItemDicList[i];
			excelDataAsset.items[i] = new MonsterExcelItem();
			excelDataAsset.items[i].id = StringUtility.StringToInt(itemRowDic["id"]);
			excelDataAsset.items[i].monsterName = itemRowDic["monsterName"];
			excelDataAsset.items[i].maxHP = StringUtility.StringToFloat(itemRowDic["maxHP"]);
			excelDataAsset.items[i].actionType_1 = StringUtility.StringToEnum<MonsterAction>(itemRowDic["actionType_1"]);
			excelDataAsset.items[i].actionValue_1 = StringUtility.StringToIntArray(itemRowDic["actionValue_1"]);
			excelDataAsset.items[i].actionType_2 = StringUtility.StringToEnum<MonsterAction>(itemRowDic["actionType_2"]);
			excelDataAsset.items[i].actionValue_2 = StringUtility.StringToIntArray(itemRowDic["actionValue_2"]);
			excelDataAsset.items[i].actionType_3 = StringUtility.StringToEnum<MonsterAction>(itemRowDic["actionType_3"]);
			excelDataAsset.items[i].actionValue_3 = StringUtility.StringToIntArray(itemRowDic["actionValue_3"]);
		}
		if(!Directory.Exists(excelAssetPath))
			Directory.CreateDirectory(excelAssetPath);
		string fullPath = Path.Combine(excelAssetPath,typeof(MonsterExcelData).Name) + ".asset";
		UnityEditor.AssetDatabase.DeleteAsset(fullPath);
		UnityEditor.AssetDatabase.CreateAsset(excelDataAsset,fullPath);
		UnityEditor.AssetDatabase.Refresh();
		return true;
	}
}
#endif



