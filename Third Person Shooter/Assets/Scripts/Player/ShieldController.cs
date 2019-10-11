using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

    public PlayerMechanics player;
    Renderer rend;

    public Color defualtColor;
    public Color damagedColor;

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
        rend = GetComponent<Renderer>();
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

    public void DamageShield()
    {
        StopAllCoroutines();
        StartCoroutine(ShieldDamaged(0.075f));
    }

    IEnumerator ShieldDamaged(float returnIncrement)
    {
        float t = 1;

        while (true)
        {
            rend.material.color = Color.Lerp(defualtColor, damagedColor, t);
            t -= returnIncrement;
            yield return new WaitForSeconds(Time.deltaTime);
            Debug.Log(t);
            if (t <= 0) yield return null;
        }
    }
}
