using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController characterController;
    [SerializeField]
    float speed = 1f;
    float gravity = -9.81f;
    Vector3 velocity;
    bool groundedPlayer;
    bool isWalking = false;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Walk();
        
    }

    void Walk()
    {
        
        groundedPlayer = characterController.isGrounded;
        if(groundedPlayer && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        float hMove = Input.GetAxis("Horizontal");
        float vMove = Input.GetAxis("Vertical");
        Vector3 moveDirectionForward = transform.forward * vMove;
        Vector3 moveDirectionSide = transform.right * hMove;

        Vector3 direction = (moveDirectionForward + moveDirectionSide).normalized;
        Vector3 distance = direction * speed * Time.deltaTime;
        characterController.Move(distance);

        if (distance != Vector3.zero)
        {
            if(!isWalking){
                animator.SetBool("IsWalking", true);
                isWalking = true;
            }
        }
        else 
        {
            if(isWalking){
                animator.SetBool("IsWalking", false);
                isWalking = false;
            }
        }

        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
