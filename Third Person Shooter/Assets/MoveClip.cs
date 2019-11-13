using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MoveClip", order = 1)]
public class MoveClip : ScriptableObject
{
    public Vector3 startPos;
    public Vector3 endPos;

    public float time;
}
