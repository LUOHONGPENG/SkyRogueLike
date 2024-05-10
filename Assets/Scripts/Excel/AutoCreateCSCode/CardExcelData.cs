/*Auto Create, Don't Edit !!!*/

using UnityEngine;
using System.Collections.Generic;
using System;
using System.IO;

[Serializable]
public partial class CardExcelItem : ExcelItemBase
{
	/// <summary>
	/// 卡牌id
	/// </summary>>
	public int id;
	/// <summary>
	/// 名称
	/// </summary>>
	public string name;
	/// <summary>
	/// 描述
	/// </summary>>
	public string desc;
	/// <summary>
	/// 行为效果_0
	/// </summary>>
	public BasicActionEffect actionEffect_0;
	/// <summary>
	/// 行为范围_0
	/// </summary>>
	public BasicActionRange actionRange_0;
	/// <summary>
	/// 行为数值0
	/// </summary>>
	public int actionValue_0;
	/// <summary>
	/// 行为次数0
	/// </summary>>
	public int actionTime_0;
	/// <summary>
	/// 行为效果_1
	/// </summary>>
	public BasicActionEffect actionEffect_1;
	/// <summary>
	/// 行为范围_1
	/// </summary>>
	public BasicActionRange actionRange_1;
	/// <summary>
	/// 行为数值1
	/// </summary>>
	public int actionValue_1;
	/// <summary>
	/// 行为次数1
	/// </summary>>
	public int actionTime_1;
	/// <summary>
	/// 行为效果_2
	/// </summary>>
	public BasicActionEffect actionEffect_2;
	/// <summary>
	/// 行为范围_2
	/// </summary>>
	public BasicActionRange actionRange_2;
	/// <summary>
	/// 行为数值2
	/// </summary>>
	public int actionValue_2;
	/// <summary>
	/// 行为次数2
	/// </summary>>
	public int actionTime_2;
}


public partial class CardExcelData : ExcelDataBase<CardExcelItem>
{
	public CardExcelItem[] items;

	public Dictionary<int,CardExcelItem> itemDic = new Dictionary<int,CardExcelItem>();

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

	public CardExcelItem GetCardExcelItem(int id)
	{
		if(itemDic.ContainsKey(id))
			return itemDic[id];
		else
			return null;
	}
	#region --- Get Method ---

	public string GetName(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.name;
	}

	public string GetDesc(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.desc;
	}

	public BasicActionEffect GetActionEffect_0(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionEffect_0;
	}

	public BasicActionRange GetActionRange_0(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionRange_0;
	}

	public int GetActionValue_0(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionValue_0;
	}

	public int GetActionTime_0(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionTime_0;
	}

	public BasicActionEffect GetActionEffect_1(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionEffect_1;
	}

	public BasicActionRange GetActionRange_1(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionRange_1;
	}

	public int GetActionValue_1(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionValue_1;
	}

	public int GetActionTime_1(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionTime_1;
	}

	public BasicActionEffect GetActionEffect_2(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionEffect_2;
	}

	public BasicActionRange GetActionRange_2(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionRange_2;
	}

	public int GetActionValue_2(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionValue_2;
	}

	public int GetActionTime_2(int id)
	{
		var item = GetCardExcelItem(id);
		if(item == null)
			return default;
		return item.actionTime_2;
	}

	#endregion
}


#if UNITY_EDITOR
public class CardAssetAssignment
{
	public static bool CreateAsset(ExcelMediumData excelMediumData, string excelAssetPath)
	{
		var allRowItemDicList = excelMediumData.GetAllRowItemDicList();
		if(allRowItemDicList == null || allRowItemDicList.Count == 0)
			return false;

		int rowCount = allRowItemDicList.Count;
		CardExcelData excelDataAsset = ScriptableObject.CreateInstance<CardExcelData>();
		excelDataAsset.items = new CardExcelItem[rowCount];

		for(int i = 0; i < rowCount; i++)
		{
			var itemRowDic = allRowItemDicList[i];
			excelDataAsset.items[i] = new CardExcelItem();
			excelDataAsset.items[i].id = StringUtility.StringToInt(itemRowDic["id"]);
			excelDataAsset.items[i].name = itemRowDic["name"];
			excelDataAsset.items[i].desc = itemRowDic["desc"];
			excelDataAsset.items[i].actionEffect_0 = StringUtility.StringToEnum<BasicActionEffect>(itemRowDic["actionEffect_0"]);
			excelDataAsset.items[i].actionRange_0 = StringUtility.StringToEnum<BasicActionRange>(itemRowDic["actionRange_0"]);
			excelDataAsset.items[i].actionValue_0 = StringUtility.StringToInt(itemRowDic["actionValue_0"]);
			excelDataAsset.items[i].actionTime_0 = StringUtility.StringToInt(itemRowDic["actionTime_0"]);
			excelDataAsset.items[i].actionEffect_1 = StringUtility.StringToEnum<BasicActionEffect>(itemRowDic["actionEffect_1"]);
			excelDataAsset.items[i].actionRange_1 = StringUtility.StringToEnum<BasicActionRange>(itemRowDic["actionRange_1"]);
			excelDataAsset.items[i].actionValue_1 = StringUtility.StringToInt(itemRowDic["actionValue_1"]);
			excelDataAsset.items[i].actionTime_1 = StringUtility.StringToInt(itemRowDic["actionTime_1"]);
			excelDataAsset.items[i].actionEffect_2 = StringUtility.StringToEnum<BasicActionEffect>(itemRowDic["actionEffect_2"]);
			excelDataAsset.items[i].actionRange_2 = StringUtility.StringToEnum<BasicActionRange>(itemRowDic["actionRange_2"]);
			excelDataAsset.items[i].actionValue_2 = StringUtility.StringToInt(itemRowDic["actionValue_2"]);
			excelDataAsset.items[i].actionTime_2 = StringUtility.StringToInt(itemRowDic["actionTime_2"]);
		}
		if(!Directory.Exists(excelAssetPath))
			Directory.CreateDirectory(excelAssetPath);
		string fullPath = Path.Combine(excelAssetPath,typeof(CardExcelData).Name) + ".asset";
		UnityEditor.AssetDatabase.DeleteAsset(fullPath);
		UnityEditor.AssetDatabase.CreateAsset(excelDataAsset,fullPath);
		UnityEditor.AssetDatabase.Refresh();
		return true;
	}
}
#endif



