using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ExcelDataManager : Singleton<ExcelDataManager>
{
    public CardExcelData cardConfig;
    public MonsterExcelData monsterConfig;
    public MonsterActionExcelData monsterActionConfig;
    public LevelExcelData levelConfig;

    public void Init()
    {
        cardConfig = GetExcelData<CardExcelData, CardExcelItem>();
        monsterConfig = GetExcelData<MonsterExcelData, MonsterExcelItem>();
        monsterActionConfig = GetExcelData<MonsterActionExcelData, MonsterActionExcelItem>();
        levelConfig = GetExcelData<LevelExcelData, LevelExcelItem>();

        //Init all ExcelDataBase
        foreach (var keyPair in excelDataDic)
        {
            Type typeExcelData = keyPair.Key;
            MethodInfo mi = typeExcelData.GetMethod("Init");
            mi.Invoke(keyPair.Value, null);
        }

        monsterActionConfig.InitExtra();
    }

    Dictionary<Type, object> excelDataDic = new Dictionary<Type, object>();
    private string checkResourcesAssetPath = "ScriptableObject/AutoCreateAsset";

    //Get the excelData and add it into the dictionary
    public T GetExcelData<T, V>() where T : ExcelDataBase<V> where V : ExcelItemBase
    {
        Type type = typeof(T);
        if (excelDataDic.ContainsKey(type) && excelDataDic[type] is T)
            return excelDataDic[type] as T;

        T excelData = Resources.Load<T>(checkResourcesAssetPath + "/" + type.Name);

        if (excelData != null)
            excelDataDic.Add(type, excelData as T);

        return excelData;
    }

}
