using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrashData", menuName = "ScriptableObjects/TrashData", order = 2)]

public class SOs_TrashData : ScriptableObject
{
    public float speed;
    public float minRotationX;
    public float maxRotationX;
    public float minRotationY;
    public float maxRotationY;
    public float minRotationZ;
    public float maxRotationZ;
}
