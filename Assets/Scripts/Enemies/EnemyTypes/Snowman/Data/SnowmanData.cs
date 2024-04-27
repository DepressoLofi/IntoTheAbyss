using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newSnowData", menuName = "Data/EntityData/SnowData")]
public class SnowmanData : ScriptableObject
{
    public int hitPoint = 2;

    public float shootTime = 1.5f;

    public GameObject diePrefab;

}
