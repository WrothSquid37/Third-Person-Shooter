using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RapidFirePickup : MonoBehaviour {

    public float time;
    public Transform bulletsArt;
    PlayerMechanics player;
    bool triggeredOnce = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggeredOnce)
        {
            player = other.GetComponent<PlayerMechanics>();

            StartCoroutine(PowerupTime(time));
            triggeredOnce = true;
        }
    }

    IEnumerator PowerupTime (float pickupLength)
    {
        player.fireMode = 1;
        player.SetDamage(5, false);
        Destroy(bulletsArt.gameObject);
        yield return new WaitForSeconds(pickupLength);
        player.fireMode = 0;
        player.SetDamage(5, true);
        Destroy(gameObject);
    }

}
