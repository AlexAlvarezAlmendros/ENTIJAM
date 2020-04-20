using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class carMovementScript : MonoBehaviour
{

    private float speed = 5;
    private float walkAcceleration = 75;
    private float airAcceleration = 10;
    private float groundFriction = 70;
    private float jumpForce = 4;

    private bool right = true;
    private bool facingRight = true;
    private bool isjumping = false;

    private Animator anim;
    private Vector2 velocity;
    private BoxCollider2D boxCollider;
    private GameController gameController;
    private Rigidbody2D Man;
    private bool grounded;
    
    public GameObject laser;
    

    void Start()
    {
        transform.position = new Vector3(-5.65f, -3.526f, 0f);
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();

        Man = GetComponent<Rigidbody2D>();
        GameObject gameControllerObject =
            GameObject.FindWithTag("GameController");

        gameController =
            gameControllerObject.GetComponent<GameController>();

        
    }

    private void Update()
    {
        if (grounded)
        {
            velocity.y = 0;
            
            if (Input.GetButtonDown("Jump"))
            {
                anim.SetBool("isRunning", false);
                velocity.y = Mathf.Sqrt(2 * jumpForce * Mathf.Abs(Physics2D.gravity.y));
                anim.SetBool("isjumping", true);
                isjumping = true;
            }
            else
            {
                isjumping = false;
                anim.SetBool("isjumping", false);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            ShootLaser(right);
            anim.SetTrigger("Shoot"); ;
        }

        velocity.y += Physics2D.gravity.y * Time.deltaTime;
        float moveInput = Input.GetAxisRaw("Horizontal");
        if (moveInput != 0)
        {
            velocity.x = Mathf.MoveTowards(velocity.x, speed * moveInput, walkAcceleration * Time.deltaTime);
            if (isjumping)
            {
                anim.SetBool("isRunning", false);
            }
            else
            {
                anim.SetBool("isRunning", true);
            }
            
        }
        else
        {
            velocity.x = Mathf.MoveTowards(velocity.x, 0, groundFriction * Time.deltaTime);
            anim.SetBool("isRunning", false);
        }
        if (moveInput > 0 && !facingRight)
        {
            Flip();
            right = true;
        }else if (moveInput < 0 && facingRight)
        {
            Flip();
            right = false;
        }

        transform.Translate(velocity * Time.deltaTime);
        float acceleration = grounded ? walkAcceleration : airAcceleration;
        float deceleration = grounded ? groundFriction : 0;

        Collider2D[] hits = Physics2D.OverlapBoxAll(transform.position, boxCollider.size, 0);
        grounded = false;
        foreach (Collider2D hit in hits)
        {
            if (hit == boxCollider)
                continue;

            ColliderDistance2D colliderDistance = hit.Distance(boxCollider);
            if (colliderDistance.isOverlapped)
            {
                
                transform.Translate(colliderDistance.pointA - colliderDistance.pointB);
            }
            if (Vector2.Angle(colliderDistance.normal, Vector2.up) < 90 && velocity.y < 0)
            {
                grounded = true;
            }
        }
    }

    void FixedUpdate()
    {


    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag.Equals("Final"))
        {
            SceneManager.LoadScene("YouWin");
        }

    }
    void ShootLaser(bool right)
    {
        if (right)
        {
            Instantiate(laser,
            new Vector3(transform.position.x + 1, transform.position.y, 0),
            transform.rotation);
        }
        else
        {
            Instantiate(laser,
            new Vector3(transform.position.x -1, transform.position.y, 0),
            transform.rotation);
        }
            
        
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
