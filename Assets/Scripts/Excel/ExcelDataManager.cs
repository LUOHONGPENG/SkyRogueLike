using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ExcelDataManager : Singleton<ExcelDataManager>
{
    public MonsterExcelData monsterConfig;
    public void Init()
    {
        monsterConfig = GetExcelData<MonsterExcelData, MonsterExcelItem>();

        //Init all ExcelDataBase
        foreach (var keyPair in excelDataDic)
        {
            Type typeExcelData = keyPair.Key;
            MethodInfo mi = typeExcelData.GetMethod("Init");
            mi.Invoke(keyPair.Value, null);
        }
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
