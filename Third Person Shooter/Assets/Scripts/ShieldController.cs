using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

    public PlayerMechanics player;

    Vector3 initialSize;
    Vector3 currentSize;
    Vector3 endSize;

    float initialHp = 0;

    void Start()
    {
        initialSize = transform.localScale;
        currentSize = initialSize;
        endSize = transform.parent.localScale;
        initialHp = player.shieldHp;
    }

    void Update()
    {
        if (player.shieldActivated)
        {
            currentSize.z = Mathf.Lerp(initialSize.z, endSize.z, player.shieldHp / initialHp);
            currentSize.x = Mathf.Lerp(initialSize.x, endSize.x, player.shieldHp / initialHp);
            currentSize.y = Mathf.Lerp(initialSize.y, endSize.y, player.shieldHp / initialHp);
            transform.localScale = currentSize;
        }
        else
        {
            transform.localScale = new Vector3(0, 0, 0);
        }
    }
}
