using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public Transform container;

    public bool hiddenByDefualt = true;

    private void Start()
    {
        container.gameObject.SetActive(hiddenByDefualt);
    }

    public void ShowMenu()
    {
        container.gameObject.SetActive(true);
    }
}
