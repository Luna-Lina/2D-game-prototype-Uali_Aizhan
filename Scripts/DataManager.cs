using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public Vector3 _pos;

    public SomeData _data;

    public void SavePosition()
    {
        _data = new SomeData(new Vector3(12, 43, 34), new float[3] { 2.3f, 2.2f, 4.4f }, "Mushroom");

        string json = JsonUtility.ToJson(_data);

        PlayerPrefs.SetString("JSON", json);
    }

    public void LoadPosition()
    {
        _data = JsonUtility.FromJson<SomeData>(PlayerPrefs.GetString("JSON"));
    }

    public void DelData()
    {
        PlayerPrefs.DeleteAll();
    }
}

[Serializable]
public class SomeData
{
    public Vector3 Pos;
    public float[] SomeArray;
    public string SomeName;

    public SomeData() { }

    public SomeData(Vector3 pos, float[] someArray, string someName)
    {
        Pos = pos;
        SomeArray = someArray;
        SomeName = someName;
    }
}