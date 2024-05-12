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
	public int maxHP;
	/// <summary>
	/// 行动0
	/// </summary>>
	public MonsterAction actionType_0;
	/// <summary>
	/// 行动0数值
	/// </summary>>
	public int[] actionValue_0;
	/// <summary>
	/// 行动0次数
	/// </summary>>
	public int[] actionTime_0;
	/// <summary>
	/// 行动1
	/// </summary>>
	public MonsterAction actionType_1;
	/// <summary>
	/// 行动1数值
	/// </summary>>
	public int[] actionValue_1;
	/// <summary>
	/// 行动1次数
	/// </summary>>
	public int[] actionTime_1;
	/// <summary>
	/// 行动2
	/// </summary>>
	public MonsterAction actionType_2;
	/// <summary>
	/// 行动2数值
	/// </summary>>
	public int[] actionValue_2;
	/// <summary>
	/// 行动2次数
	/// </summary>>
	public int[] actionTime_2;
	/// <summary>
	/// 图片路径
	/// </summary>>
	public string iconUrl;
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

	public int GetMaxHP(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.maxHP;
	}

	public MonsterAction GetActionType_0(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionType_0;
	}

	public int[] GetActionValue_0(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionValue_0;
	}
	public int GetActionValue_0(int id, int index)
	{
		var item0 = GetMonsterExcelItem (id);
		if(item0 == null)
			return default;
		var item1 = item0.actionValue_0;
		if(item1 == null || index < 0 || index >= item1.Length)
			return default;
		return item1[index];
	}

	public int[] GetActionTime_0(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionTime_0;
	}
	public int GetActionTime_0(int id, int index)
	{
		var item0 = GetMonsterExcelItem (id);
		if(item0 == null)
			return default;
		var item1 = item0.actionTime_0;
		if(item1 == null || index < 0 || index >= item1.Length)
			return default;
		return item1[index];
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

	public int[] GetActionTime_1(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionTime_1;
	}
	public int GetActionTime_1(int id, int index)
	{
		var item0 = GetMonsterExcelItem (id);
		if(item0 == null)
			return default;
		var item1 = item0.actionTime_1;
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

	public int[] GetActionTime_2(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.actionTime_2;
	}
	public int GetActionTime_2(int id, int index)
	{
		var item0 = GetMonsterExcelItem (id);
		if(item0 == null)
			return default;
		var item1 = item0.actionTime_2;
		if(item1 == null || index < 0 || index >= item1.Length)
			return default;
		return item1[index];
	}

	public string GetIconUrl(int id)
	{
		var item = GetMonsterExcelItem(id);
		if(item == null)
			return default;
		return item.iconUrl;
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
			excelDataAsset.items[i].maxHP = StringUtility.StringToInt(itemRowDic["maxHP"]);
			excelDataAsset.items[i].actionType_0 = StringUtility.StringToEnum<MonsterAction>(itemRowDic["actionType_0"]);
			excelDataAsset.items[i].actionValue_0 = StringUtility.StringToIntArray(itemRowDic["actionValue_0"]);
			excelDataAsset.items[i].actionTime_0 = StringUtility.StringToIntArray(itemRowDic["actionTime_0"]);
			excelDataAsset.items[i].actionType_1 = StringUtility.StringToEnum<MonsterAction>(itemRowDic["actionType_1"]);
			excelDataAsset.items[i].actionValue_1 = StringUtility.StringToIntArray(itemRowDic["actionValue_1"]);
			excelDataAsset.items[i].actionTime_1 = StringUtility.StringToIntArray(itemRowDic["actionTime_1"]);
			excelDataAsset.items[i].actionType_2 = StringUtility.StringToEnum<MonsterAction>(itemRowDic["actionType_2"]);
			excelDataAsset.items[i].actionValue_2 = StringUtility.StringToIntArray(itemRowDic["actionValue_2"]);
			excelDataAsset.items[i].actionTime_2 = StringUtility.StringToIntArray(itemRowDic["actionTime_2"]);
			excelDataAsset.items[i].iconUrl = itemRowDic["iconUrl"];
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



