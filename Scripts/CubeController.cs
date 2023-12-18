using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public CubeData cubeData = new CubeData();

    private void FixedUpdate()
    {
        var xAxis = Input.GetAxis("Horizontal");

        transform.position = Vector3.Lerp(new Vector3(transform.position.x + xAxis, 0, 0), transform.position, Time.deltaTime * 2);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            SaveData();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            LoadData();
        }
    }

    public void SaveData()
    {
        cubeData = new CubeData(transform.position, gameObject.name);

        string json = JsonUtility.ToJson(cubeData);

        string path = Path.Combine(Application.persistentDataPath, "GAMEDATA.json");

        Debug.Log(path);

        File.WriteAllText(path, json);

        Debug.Log("Saved new position: " + json);
    }

    public void LoadData()
    {
        string path = Path.Combine(Application.persistentDataPath, "GAMEDATA.json");

        cubeData = JsonUtility.FromJson<CubeData>(File.ReadAllText(path));

        transform.position = cubeData.Position;

        Debug.Log("Loaded old position name of: " + cubeData.Name);
    }
}

[Serializable]
public class CubeData
{
    public Vector3 Position;
    public string Name;

    public CubeData() { }

    public CubeData(Vector3 position, string name)
    {
        Position = position;
        Name = name;
    }
}