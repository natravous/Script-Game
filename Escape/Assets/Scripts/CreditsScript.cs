using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScript : MonoBehaviour
{

    public float transitionTime = 1f;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    LoadNextScene();
        //}
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel("Menu"));
    }

    IEnumerator LoadLevel(string levelName)
    {
        //wait
        yield return new WaitForSeconds(transitionTime);

        //laod scene
        SceneManager.LoadScene(levelName);
    }
}
