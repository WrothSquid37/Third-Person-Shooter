using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public List<Transform> prefabs;

    public float timeInterval;
    public Transform[] spawnPlaces = new Transform[4];
    int rand1 = 0;
    int rand2 = 0;

    private void Start()
    {
        Debug.Log(prefabs.Count);
        StartCoroutine(spawnTimer());     
    }

    IEnumerator spawnTimer()
    {
        while (true)
        {
            rand1 = Random.Range(0, spawnPlaces.Length);
            rand2 = Random.Range(1, prefabs.Count);

            Debug.Log(rand1 + " : " + rand2);

            Instantiate(prefabs[rand2], spawnPlaces[rand1].position, Quaternion.identity);

            yield return new WaitForSeconds(timeInterval);
        }
    }

}
