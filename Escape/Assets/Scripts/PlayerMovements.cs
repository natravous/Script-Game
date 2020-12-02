using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public PlayerState playerState;
    public KeyHolder keyHolder;

    float horizontalMove = 0f;

    private WaitForSeconds regenEnergi = new WaitForSeconds(0.1f);
    private Coroutine regenerasi;

    bool run = false;
    bool jump = false;
    public bool crouch = false;
    // Start is called before the first frame update
    void Start()
    {
        //playerState.power = 100;

        playerState.currentEnergi = playerState.maxEnergi;

        playerState.runSpeed = 20f;
        Debug.Log("Energi: " + playerState.currentEnergi);
        keyHolder = gameObject.AddComponent<KeyHolder>() as KeyHolder;

        StaminaBar.instance.GetComponent<StaminaBar>();
    }

    // Update is called once per frame
    private void Update()
    {
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * playerState.runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        } else if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        if(playerState.currentEnergi >=0 && playerState.currentEnergi <=100)
        {
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerState.runSpeed = 40f;
                Debug.Log("Shift on");
                run = true;

            }
            else if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerState.runSpeed = 20f;
                run = false;
                Debug.Log("Shift off");

            // if(power <= 100){
            //     power = power-20;
            // }
            }
        //Debug.Log(playerState.power);
        //Debug.Log(playerState.runSpeed);
        }

        playerState.crouch = crouch;
        // else if (power <100){
        //     power+=2;
        
        // }
        // Debug.Log(runSpeed);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
        if(playerState.currentEnergi <= playerState.maxEnergi && run == true)
        {
            Debug.Log("RUNNNN");
            playerState.currentEnergi -= 1;
            Debug.Log("Energi: " + playerState.currentEnergi);
            StaminaBar.instance.UseStamina(1);


            if (playerState.currentEnergi == 0)
            {
                run = false;
                // playerState.runSpeed = playerState.runSpeed + playerState.runSpeedInitial;
                playerState.runSpeed = 20f;

                Debug.Log("ENERGI HABIS");
                
            }

            if (regenerasi != null)
            {
                StopCoroutine(regenerasi);
            }

            regenerasi = StartCoroutine(RegenEnergi());
        }
        else
        {
            //if(playerState.power <100)
            //{
            //    playerState.power += 1;
            //}
            

        }
    }

    private IEnumerator RegenEnergi()
    {
        yield return new WaitForSeconds(2);

        while(playerState.currentEnergi < playerState.maxEnergi)
        {
            playerState.currentEnergi += playerState.maxEnergi / 100;
            yield return regenEnergi;
            Debug.Log("Energi menjadi: " + playerState.currentEnergi);
        }
        regenerasi = null;
    }


    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision);
        Key key = collision.GetComponent<Key>(); //collide with something that contain key component
        Debug.Log(keyHolder);
        if(key != null)
        {
           keyHolder.Addkey(key.GetKeyType());
           Destroy(key.gameObject);
        }
        
        KeyDoor keyDoor = collision.GetComponent<KeyDoor>();
        if(keyDoor != null)
        {
            if (keyHolder.ContainsKey(keyDoor.GetKeyType()))
            {
                //currently holding key to open this door
                Debug.Log(playerState.crouch);
                    keyHolder.RemoveKey(keyDoor.GetKeyType());
                    keyDoor.OpenDoor();
                
                
            }
        }

        
    }
}
