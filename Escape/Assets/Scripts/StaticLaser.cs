using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StaticLaser : MonoBehaviour
{

    public float timeDestroy = 1f;
    int rand;

    private void Awake()
    {
        rand = Random.Range(1, 5);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Waktu());
    }

    IEnumerator Waktu()
    {
        yield return new WaitForSeconds(rand);
        //yield return new WaitForSeconds(timeDestroy);
        Destroy(gameObject);
    }

}
