using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public PlayerMechanics player;

    Vector3 initialSize;
    Vector3 currentSize;

    void Start()
    {
        initialSize = transform.localScale;
        currentSize = initialSize;
    }

    void Update()
    {
        currentSize.z = Mathf.Lerp(0, initialSize.z, player.hp / 100);
        currentSize.x = Mathf.Lerp(0, initialSize.x, player.hp / 100);
        currentSize.y = Mathf.Lerp(0, initialSize.y, player.hp / 100);
        transform.localScale = currentSize;
    }

}
