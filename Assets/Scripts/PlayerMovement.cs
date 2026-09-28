using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;

    private Vector2 movement;
    private Rigidbody2D body;
    private Animator anim;
    private bool p_facingRight = true;

    //private bool grounded;
    //private bool jumpHeld;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        movement = Vector2.zero;

        if (Keyboard.current.wKey.isPressed)
            movement.y = 1;

        if (Keyboard.current.sKey.isPressed)
            movement.y = -1;

        if (Keyboard.current.aKey.isPressed)
            movement.x = -1;

        if (Keyboard.current.dKey.isPressed)
            movement.x = 1;

        movement = movement.normalized;

        // Walk animation
        anim.SetBool("walk", movement.magnitude > 0.01f);
        
        // Jump animation
        /* if (jumpHeld && grounded)
         {
             grounded = false;
             anim.SetTrigger("jump");
         }

         // Grounded/Idle animation
         anim.SetBool("grounded", grounded);*/
    }

    private void FixedUpdate()
    {
        body.linearVelocity = movement * speed;

        if(movement.x > 0 && !p_facingRight)
        {
            Flip();
        }
        else if(movement.x < 0  && p_facingRight)
        {
            Flip();
        }
    }

    private void Flip()
    {
        p_facingRight = !p_facingRight;

        transform.Rotate(0f, 180f, 0f);
    }
    
    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            grounded = true;
        }
    }*/
}
