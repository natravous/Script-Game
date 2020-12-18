using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour
{
    public GameObject otherObject;
    public Animator animator;
    private AnimasiPintu pintu;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            //gameObject.SetActive(false);
            //pintu.BukaPintu();
            //otherObject.GetComponent<Animator>().SetBool("Buka", true);
            //pintu2.SetBool("Buka", true);

            otherObject.SetActive(false);
            animator.SetBool("Stop", true);

        }

    }


}
