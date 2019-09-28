using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour {

    public Transform teleportDestination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.transform.position = teleportDestination.position;
        }
    }
}
