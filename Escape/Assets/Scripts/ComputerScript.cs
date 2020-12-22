using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerScript : MonoBehaviour
{
    public GameObject otherObject;
    public Animator animator;
    //private AnimasiPintu pintu;

    public float onTime = 2f;
    public float offTime = 2f;


    public bool onAnimation = false;
    public bool onBoth = false;
    public bool featureOn = false;

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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(onBoth == true && featureOn == true)
            ActiveLaser();

       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {

            //gameObject.SetActive(false);
            //pintu.BukaPintu();
            
            //animator.SetBool("Buka", true);
            //pintu2.SetBool("Buka", true);

            if(onAnimation == true)
                otherObject.GetComponent<Animator>().SetBool("Buka", true);
            if (onBoth == true)
                NonActiveLaser();
        }

    }

    public void ActiveLaser()
    {
        StartCoroutine(OnLaser());
    }

    public void NonActiveLaser()
    {
        StartCoroutine(OffLaser());
    }

    IEnumerator OnLaser()
    {
        yield return new WaitForSeconds(onTime);

        otherObject.SetActive(true);
        animator.SetBool("Stop", false);
    }

    IEnumerator OffLaser()
    {
        yield return new WaitForSeconds(offTime);

        otherObject.SetActive(false);
        animator.SetBool("Stop", true);
    }


}
