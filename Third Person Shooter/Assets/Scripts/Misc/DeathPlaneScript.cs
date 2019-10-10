using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlaneScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerMechanics>().hp = 0;
        }
        if (other.transform.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

}
