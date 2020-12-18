using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linescript : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        //rb.rotation = Random.Range(0f, 360f);
        //transform.position = Vector3.up * 10f;

        rb.velocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Vector3.up * speed * Time.deltaTime;
        //transform.Translate(Vector3.up * Time.deltaTime * speed);

        //if (transform.position.x <= 100f)
        //    Destroy(gameObject);

    }
}
