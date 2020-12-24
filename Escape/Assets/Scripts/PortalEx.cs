using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PortalEx : MonoBehaviour
{
    public float transitionTime = 0f;
    public Animator transition;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            StartCoroutine(Delay(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    IEnumerator Delay(int IndexSc)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(IndexSc);
    }

}
