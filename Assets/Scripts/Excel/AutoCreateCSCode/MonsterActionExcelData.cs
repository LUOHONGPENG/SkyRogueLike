/*Auto Create, Don't Edit !!!*/

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public partial class MonsterActionExcelItem : ExcelItemBase
{
	/// <summary>
	/// 怪物id
	/// </summary>>
	public int id;
	/// <summary>
	/// 行动名
	/// </summary>>
	public MonsterAction monsterActionName;
	/// <summary>
	/// 效果0
	/// </summary>>
	public BasicActionEffect actionEffect_0;
	/// <summary>
	/// 范围0
	/// </summary>>
	public BasicActionRange actionRange_0;
	/// <summary>
	/// 效果1
	/// </summary>>
	public BasicActionEffect actionEffect_1;
	/// <summary>
	/// 范围1
	/// </summary>>
	public BasicActionRange actionRange_1;
}


public partial class MonsterActionExcelData : ExcelDataBase<MonsterActionExcelItem>
{
	public MonsterActionExcelItem[] items;

	public Dictionary<int,MonsterActionExcelItem> itemDic = new Dictionary<int,MonsterActionExcelItem>();

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

	public MonsterActionExcelItem GetMonsterActionExcelItem(int id)
	{
		if(itemDic.ContainsKey(id))
			return itemDic[id];
		else
			return null;
	}
	#region --- Get Method ---

	public MonsterAction GetMonsterActionName(int id)
	{
		var item = GetMonsterActionExcelItem(id);
		if(item == null)
			return default;
		return item.monsterActionName;
	}

	public BasicActionEffect GetActionEffect_0(int id)
	{
		var item = GetMonsterActionExcelItem(id);
		if(item == null)
			return default;
		return item.actionEffect_0;
	}

	public BasicActionRange GetActionRange_0(int id)
	{
		var item = GetMonsterActionExcelItem(id);
		if(item == null)
			return default;
		return item.actionRange_0;
	}

	public BasicActionEffect GetActionEffect_1(int id)
	{
		var item = GetMonsterActionExcelItem(id);
		if(item == null)
			return default;
		return item.actionEffect_1;
	}

	public BasicActionRange GetActionRange_1(int id)
	{
		var item = GetMonsterActionExcelItem(id);
		if(item == null)
			return default;
		return item.actionRange_1;
	}

	#endregion
}


#if UNITY_EDITOR
public class MonsterActionAssetAssignment
{
	public static bool CreateAsset(ExcelMediumData excelMediumData, string excelAssetPath)
	{
		var allRowItemDicList = excelMediumData.GetAllRowItemDicList();
		if(allRowItemDicList == null || allRowItemDicList.Count == 0)
			return false;

		int rowCount = allRowItemDicList.Count;
		MonsterActionExcelData excelDataAsset = ScriptableObject.CreateInstance<MonsterActionExcelData>();
		excelDataAsset.items = new MonsterActionExcelItem[rowCount];

		for(int i = 0; i < rowCount; i++)
		{
			var itemRowDic = allRowItemDicList[i];
			excelDataAsset.items[i] = new MonsterActionExcelItem();
			excelDataAsset.items[i].id = StringUtility.StringToInt(itemRowDic["id"]);
			excelDataAsset.items[i].monsterActionName = StringUtility.StringToEnum<MonsterAction>(itemRowDic["monsterActionName"]);
			excelDataAsset.items[i].actionEffect_0 = StringUtility.StringToEnum<BasicActionEffect>(itemRowDic["actionEffect_0"]);
			excelDataAsset.items[i].actionRange_0 = StringUtility.StringToEnum<BasicActionRange>(itemRowDic["actionRange_0"]);
			excelDataAsset.items[i].actionEffect_1 = StringUtility.StringToEnum<BasicActionEffect>(itemRowDic["actionEffect_1"]);
			excelDataAsset.items[i].actionRange_1 = StringUtility.StringToEnum<BasicActionRange>(itemRowDic["actionRange_1"]);
		}
		if(!Directory.Exists(excelAssetPath))
			Directory.CreateDirectory(excelAssetPath);
		string fullPath = Path.Combine(excelAssetPath,typeof(MonsterActionExcelData).Name) + ".asset";
		UnityEditor.AssetDatabase.DeleteAsset(fullPath);
		UnityEditor.AssetDatabase.CreateAsset(excelDataAsset,fullPath);
		UnityEditor.AssetDatabase.Refresh();
		return true;
	}
}
#endif



