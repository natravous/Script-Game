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

    
    bool run = false;
    bool jump = false;
    public bool crouch = false;
    // Start is called before the first frame update
    void Start()
    {
        playerState.power = 100f;
        playerState.runSpeed = 20f;
        Debug.Log(playerState.power);
        keyHolder= gameObject.AddComponent<KeyHolder>() as KeyHolder;
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

        if(playerState.power >=0 && playerState.power <=1000){
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerState.runSpeed = 40f;
                Debug.Log("Shift on");
                run = true;
            } else if(Input.GetKeyUp(KeyCode.LeftShift))
            {
                playerState.runSpeed = 20f;
                run = false;
                Debug.Log("Shift off");
            // if(power <= 100){
            //     power = power-20;
            // }
            }
        Debug.Log(playerState.power);
        Debug.Log(playerState.runSpeed);
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
        
        if(run == true)
        {
            Debug.Log("RUNNNN");
            playerState.power -= 1f;
            if(playerState.power <= 0)
            {
                run = false;
                // playerState.runSpeed = playerState.runSpeed + playerState.runSpeedInitial;
                playerState.runSpeed = 20f;
            }
        }else
        {
            if(playerState.power <100)
            {
                playerState.power += .5f;
            }
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }
    private void OnTriggerEnter2D(Collider2D collision){
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
