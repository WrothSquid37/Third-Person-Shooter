﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDropper : MonoBehaviour {

	public List<Transform> pickupPrefabs;

    public void spawnPickup()
    {
        int rand1 = Random.Range(0, pickupPrefabs.Count + 1);

        if (!(rand1 > pickupPrefabs.Count - 1)) Instantiate(pickupPrefabs[rand1], transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
    }
}
