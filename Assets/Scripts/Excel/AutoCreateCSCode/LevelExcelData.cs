/*Auto Create, Don't Edit !!!*/

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public partial class LevelExcelItem : ExcelItemBase
{
	/// <summary>
	/// 关卡id
	/// </summary>>
	public int id;
	/// <summary>
	/// 怪物ID列表
	/// </summary>>
	public int[] listMonsterID;
	/// <summary>
	/// 怪物数量列表
	/// </summary>>
	public int[] listMonsterNum;
}


public partial class LevelExcelData : ExcelDataBase<LevelExcelItem>
{
	public LevelExcelItem[] items;

	public Dictionary<int,LevelExcelItem> itemDic = new Dictionary<int,LevelExcelItem>();

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

	public LevelExcelItem GetLevelExcelItem(int id)
	{
		if(itemDic.ContainsKey(id))
			return itemDic[id];
		else
			return null;
	}
	#region --- Get Method ---

	public int[] GetListMonsterID(int id)
	{
		var item = GetLevelExcelItem(id);
		if(item == null)
			return default;
		return item.listMonsterID;
	}
	public int GetListMonsterID(int id, int index)
	{
		var item0 = GetLevelExcelItem (id);
		if(item0 == null)
			return default;
		var item1 = item0.listMonsterID;
		if(item1 == null || index < 0 || index >= item1.Length)
			return default;
		return item1[index];
	}

	public int[] GetListMonsterNum(int id)
	{
		var item = GetLevelExcelItem(id);
		if(item == null)
			return default;
		return item.listMonsterNum;
	}
	public int GetListMonsterNum(int id, int index)
	{
		var item0 = GetLevelExcelItem (id);
		if(item0 == null)
			return default;
		var item1 = item0.listMonsterNum;
		if(item1 == null || index < 0 || index >= item1.Length)
			return default;
		return item1[index];
	}

	#endregion
}


#if UNITY_EDITOR
public class LevelAssetAssignment
{
	public static bool CreateAsset(ExcelMediumData excelMediumData, string excelAssetPath)
	{
		var allRowItemDicList = excelMediumData.GetAllRowItemDicList();
		if(allRowItemDicList == null || allRowItemDicList.Count == 0)
			return false;

		int rowCount = allRowItemDicList.Count;
		LevelExcelData excelDataAsset = ScriptableObject.CreateInstance<LevelExcelData>();
		excelDataAsset.items = new LevelExcelItem[rowCount];

		for(int i = 0; i < rowCount; i++)
		{
			var itemRowDic = allRowItemDicList[i];
			excelDataAsset.items[i] = new LevelExcelItem();
			excelDataAsset.items[i].id = StringUtility.StringToInt(itemRowDic["id"]);
			excelDataAsset.items[i].listMonsterID = StringUtility.StringToIntArray(itemRowDic["listMonsterID"]);
			excelDataAsset.items[i].listMonsterNum = StringUtility.StringToIntArray(itemRowDic["listMonsterNum"]);
		}
		if(!Directory.Exists(excelAssetPath))
			Directory.CreateDirectory(excelAssetPath);
		string fullPath = Path.Combine(excelAssetPath,typeof(LevelExcelData).Name) + ".asset";
		UnityEditor.AssetDatabase.DeleteAsset(fullPath);
		UnityEditor.AssetDatabase.CreateAsset(excelDataAsset,fullPath);
		UnityEditor.AssetDatabase.Refresh();
		return true;
	}
}
#endif



