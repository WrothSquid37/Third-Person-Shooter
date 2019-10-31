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
        StartCoroutine(spawnTimer());     
    }

    public void stopSpawning()
    {
        StopAllCoroutines();
    }

    IEnumerator spawnTimer()
    {
        while (true)
        {
            rand1 = Random.Range(0, spawnPlaces.Length);
            rand2 = Random.Range(0, prefabs.Count);

            Instantiate(prefabs[rand2], spawnPlaces[rand1].position, Quaternion.identity);

            yield return new WaitForSeconds(timeInterval);
        }
    }

}
