using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllMenus : MonoBehaviour {

    public Transform menu1;
    public Transform menu2;

    public void Back()
    {
        menu1.gameObject.SetActive(true);
        menu2.gameObject.SetActive(false);
    }

    public void Options()
    {
        menu1.gameObject.SetActive(false);
        menu2.gameObject.SetActive(true);
    }

}
