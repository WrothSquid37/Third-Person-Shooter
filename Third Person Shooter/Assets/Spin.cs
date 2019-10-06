using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour {

    public Transform target;
    public float speed;

    private void Update()
    {
        transform.RotateAround(target.position, target.up, speed * Time.deltaTime);
    }

}
