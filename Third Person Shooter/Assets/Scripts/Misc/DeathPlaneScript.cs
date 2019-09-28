using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPlaneScript : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
        if (other.transform.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
        }
    }

}
