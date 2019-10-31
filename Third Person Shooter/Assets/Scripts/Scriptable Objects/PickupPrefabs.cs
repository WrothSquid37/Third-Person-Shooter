using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/PickupPrefab", order = 1)]
public class PickupPrefabs : ScriptableObject
{
    public List<Transform> prefabs;
}
