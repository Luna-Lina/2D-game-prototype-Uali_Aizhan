using System;
using UnityEngine;

[Serializable]
public class PlayerData
{
    public float[] position;

    public PlayerData(Vector3 playerPosition)
    {
        position = new float[3];
        position[0] = playerPosition.x;
        position[1] = playerPosition.y;
        position[2] = playerPosition.z;
    }
}
