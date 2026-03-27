using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float jumpForce = 200f;
    private int jumpCount = 0;

    private bool isGrounded = false;
    private bool isSlide = false;
    
    public bool isDead = false;
    public bool isImmune = false;

    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D col;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();

    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Jump();
        Slide();


        animator.SetBool("Grounded", isGrounded);
        animator.SetBool("Slide", isSlide);

    }


    void Jump()
    {

        if (Input.GetButtonDown("Fire1") && jumpCount < 2)
        {
            jumpCount++;

            rb.linearVelocity = Vector2.zero;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            Debug.Log("jump");

            if (isSlide)
            {
                isSlide = false;
                isGrounded = false;

                col.offset = new Vector2(col.offset.x, col.offset.y + 0.25f);
                col.size = new Vector2(col.size.x, col.size.y * 2f);
            }

        }
        else if (Input.GetButtonUp("Fire1") && rb.linearVelocity.y > 0)
        {
            rb.linearVelocity *= 0.5f;
        }

    }

    void Slide()
    {


        if (Input.GetKey(KeyCode.S) && !isSlide && isGrounded)
        {
            isSlide = true;

            col.offset = new Vector2(col.offset.x, col.offset.y - 0.15f);
            col.size = new Vector2(col.size.x, col.size.y * 0.5f);


            Debug.Log("slide");
        }
        else if (Input.GetKeyUp(KeyCode.S) && isSlide)
        {
            isSlide = false;

            col.offset = new Vector2(col.offset.x, col.offset.y + 0.15f);

            col.size = new Vector2(col.size.x, col.size.y * 2f);
        }


    }

    public void Die()
    {
        isDead = true;
        animator.SetTrigger("isDead");

        rb.linearVelocity = Vector2.zero;
        rb.bodyType = RigidbodyType2D.Kinematic;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Platform"))
        {
            isGrounded = true;
            jumpCount = 0;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Platform"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Dead"))
        {
            Die();
        }
    }
}
