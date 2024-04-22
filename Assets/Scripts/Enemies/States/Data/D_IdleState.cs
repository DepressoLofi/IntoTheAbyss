using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="newIdleData", menuName ="Data/StateData/IdleData")]
public class D_IdleState : ScriptableObject
{
    public float minIdleTime = 0.1f;
    public float maxIdleTime = 0.4f;

}
