using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSplashScript : MonoBehaviour {

    public GameObject controlSplash;
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(10f);
        controlSplash.SetActive(true);
        yield return new WaitForSeconds(10f);
        SceneManager.LoadSceneAsync("ExplorerSceneProto");
    }
}
