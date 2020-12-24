using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile: MonoBehaviour
{
    public float speed = 3f;

    public float timeDestroy = 4f;

    private Transform pl;

    private Vector3 r = new Vector3(0, 0, 270);



    private void Start()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + 270);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z+90);

        StartCoroutine(Waktu());
    }

    IEnumerator Waktu()
    {
        yield return new WaitForSeconds(timeDestroy);
        Destroy(gameObject);
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Tile")
    //    {
    //        Debug.Log("Kena Tile");
    //        Destroy(gameObject);
    //    }
    //}



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("KENA!");
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
