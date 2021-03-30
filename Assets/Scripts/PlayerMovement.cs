using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;

    bool moveLeft;
    bool moveRight;
    bool moveForward;
    bool moveBackward;
    float horizontalMove;
    float verticalMove;
    public float speed = 300;

    public float jumpSpeed = 5;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //LEFT BUTTON

    public void PointerDownLeft() 
    { 
        moveLeft = true;
    }

    public void PointerUpLeft() 
    { 
        moveLeft = false;
    }

     //RIGHT BUTTON
    
    public void PointerDownRight() 
    { 
        moveRight = true;
    }

    public void PointerUpRight() 
    { 
        moveRight = false;
    }

     //FORWARD BUTTON
    
    public void PointerDownForward() 
    { 
        moveForward = true;
    }

    public void PointerUpForward() 
    { 
        moveForward = false;
    }

     //BACKWARD BUTTON
    
    public void PointerDownBackward() 
    { 
        moveBackward = true;
    }

    public void PointerUpBackward() 
    { 
        moveBackward = false;
    }

    private void Update()
    {   
        Movement();
    }

    void Movement() 
    {   
        if(moveLeft) 
        {   
            horizontalMove = -speed;
        }
        else if (moveRight)
        {   
            horizontalMove = speed;
        }
        else 
        {   
            horizontalMove = 0;
        }

        if(moveForward)
        {   
            verticalMove = speed;
        }
        else if (moveBackward)
        {   
            verticalMove = -speed;
        }
        else 
        {   
            verticalMove = 0;
        }
    }

    public void Jump()
    {   
        if(isGrounded)
        {   
            rb.AddForce(0, jumpSpeed, 0, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision other)
    {   
        if (other.gameObject.CompareTag("Ground"))
        {   
            isGrounded = true;
        }
    }

    

    private void FixedUpdate()
    {   
        rb.velocity = new Vector3(horizontalMove * Time.deltaTime, rb.velocity.y, verticalMove * Time.deltaTime);
    }
}
