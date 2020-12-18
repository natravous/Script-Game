using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luncur : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector2 target;
    private float Pose;

    private Vector3 shootdir;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        Pose = Random.Range(10f, 90f);
        //shootdir = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        //shootdir = target - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootdir));

        if (transform.position.x == target.x)
        {
            AncurPeluru();
        }
    }

    //public void Setup(Vector3 shoodir)
    //{
    //    this.shootdir = shootdir;
    //    transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootdir));
    //}

    //public static float GetAngleFromVectorFloat(Vector3 dir)
    //{
    //    dir = dir.normalized;
        
    //    float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //    if (n < 0) n += 360;

    //    return n;
    //}

    void AncurPeluru()
    {
        Destroy(gameObject);
    }
}
