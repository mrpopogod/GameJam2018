using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RespawnController : MonoBehaviour {
	
	void Update ()
    {
        var player = GameObject.FindWithTag("Player");
        if (player == null)
        {
            StartCoroutine(RestartLevel());
        }
	}

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
