using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Genji : MonoBehaviour
{
    public static int lives;
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject Shuriken;

    public float jumpSpeed;
    public float speed;
    public float wallClimbSpeed;
    public float dashDistance;

    public int jumpCount;
    public int deathDelay;

    public bool facingRight;
    public bool active;
    public bool isGrounded;
    public bool dashActive;
    public bool moving;
    public bool onWall;
    public bool isWallJumping;
    public bool canShoot;
    public bool isOnCeiling;
    public bool isCeilingDashing;

    public AudioClip throwSound;

    //Variable Initialization
    void Start()
    {
        lives = 1;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        rb.freezeRotation = true;

        jumpSpeed = 5.0f;
        wallClimbSpeed = 5.0f;
        speed = 3.0f;

        jumpCount = 0;
        deathDelay = 1;
        dashDistance = 3;

        facingRight = true;
        active = true;
        dashActive = true;
        canShoot = true;
        moving = false;
        onWall = false;
        isGrounded = false;
        isWallJumping = false;
        isOnCeiling = false;
        isCeilingDashing = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 1)
        {
            active = false;
            Invoke("GameOver", deathDelay);
            anim.SetTrigger("die");
            CompletionScript.completed = 0;
        }
        else
        {
            //Shuriken Logic
            if (!onWall && active && canShoot)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    throwSnowball(0, 10, 0.0f, 0.4f);
                }
                else if (Input.GetKeyDown(KeyCode.E))
                {
                    throwSnowball(7, 7, 0.3f, 0.4f);
                }
                else if (Input.GetKeyDown(KeyCode.X) && !isGrounded)
                {
                    throwSnowball(-7, 7, -0.3f, 0.4f);
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    throwSnowball(0, -10, 0.0f, -0.4f);
                }
                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    throwSnowball(7, -7, 0.3f, -0.4f);
                }
                else if (Input.GetKeyDown(KeyCode.Z) && !isGrounded)
                {
                    throwSnowball(-7, -7, -0.3f, -0.4f);
                }
                else if (Input.GetKeyDown(KeyCode.W))
                {
                    throwSnowball(10, 0, 0.3f, 0.0f);
                }
                else if (Input.GetKeyDown(KeyCode.S) && !isGrounded)
                {
                    throwSnowball(-10, 0, -0.3f, 0.0f);
                }
            }
        }

        float xVelocity = rb.velocity.x;

        if (active)
        {
        
            //WallClimb Logic
            if (onWall && !isWallJumping && !isGrounded)
            {
                if (facingRight)
                {
                    //Jump
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        isWallJumping = true;
                        rb.velocity = new Vector2(-3.0f, jumpSpeed);
                        anim.SetTrigger("jump");
                    }
                    //Climb
                    else if (Input.GetKey(KeyCode.UpArrow))
                    {
                        rb.velocity = new Vector2(3.0f, wallClimbSpeed);
                        moving = true;
                    }
                    //Slide
                    else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        rb.velocity = new Vector2(1.0f, -4.0f);
                        moving = true;
                    }
                    //Exit
                    else if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        rb.velocity = new Vector2(-speed, rb.velocity.y);
                        moving = true;
                    }
                }
                else
                {
                    //Jump
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        isWallJumping = true;
                        rb.velocity = new Vector2(3.0f, jumpSpeed);
                        anim.SetTrigger("jump");
                    }
                    //Climb
                    else if (Input.GetKey(KeyCode.UpArrow))
                    {
                        rb.velocity = new Vector2(-3.0f, wallClimbSpeed);
                        moving = true;
                    }
                    //Slide
                    else if (Input.GetKey(KeyCode.LeftArrow))
                    {
                        rb.velocity = new Vector2(-1.0f, -4.0f);
                        moving = true;
                    }
                    //Exit
                    else if (Input.GetKey(KeyCode.RightArrow))
                    {
                        rb.velocity = new Vector2(speed, rb.velocity.y);
                        moving = true;
                    }
                }
            }
            //Ceiling Run
            else if (isOnCeiling)
            {
                if(Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.UpArrow) && facingRight)
                {
                    rb.velocity = new Vector2(speed * 3, 8.0f);
                    moving = true;
                    if(!isCeilingDashing)
                    {
                        flip();
                        flipY();
                    }
                    isCeilingDashing = true;
                } else if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow) && !facingRight)
                {
                    rb.velocity = new Vector2(-speed * 3, 8.0f);
                    moving = true;
                    if (!isCeilingDashing)
                    {
                        flip();
                        flipY();
                    }
                    isCeilingDashing = true;
                }
                //anim.SetBool("running", true);
            }

            //Grounded Logic
            else if (isGrounded)
            {
                //Walking Logic
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    rb.velocity = new Vector2(-speed, rb.velocity.y);
                    moving = true;
                    anim.SetBool("walking", true);
                }
                else if (Input.GetKey(KeyCode.RightArrow))
                {
                    rb.velocity = new Vector2(speed, rb.velocity.y);
                    moving = true;
                    anim.SetBool("walking", true);
                }
                else
                {
                    if (moving)
                        rb.velocity = new Vector2(rb.velocity.x / 2, rb.velocity.y);
                    moving = false;
                    anim.SetBool("walking", false);
                    anim.SetBool("running", false);
                    anim.SetBool("idle", true);
                }
                //Running Logic
                if (Input.GetKey(KeyCode.LeftShift) && moving)
                {
                    rb.velocity = new Vector2(rb.velocity.x * 2, rb.velocity.y);
                    anim.SetBool("walking", false);
                    anim.SetBool("running", true);
                }
                //Jumping Logic
                if (Input.GetKey(KeyCode.Space))
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpSpeed * 1.3f);
                    anim.SetTrigger("jump");
                }
                if (onWall)
                {
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        rb.velocity = new Vector2(rb.velocity.x, wallClimbSpeed);
                    }
                }
            }

            //Arial Logic
            else
            {
                //Arial Drift Logic

                if (xVelocity > -3 && Input.GetKey(KeyCode.LeftArrow) && !isWallJumping)
                {
                    rb.velocity = new Vector2(rb.velocity.x - 0.1f, rb.velocity.y);
                    moving = true;
                }
                else if (xVelocity < 3 && Input.GetKey(KeyCode.RightArrow) && !isWallJumping)
                {
                    rb.velocity = new Vector2(rb.velocity.x + 0.1f, rb.velocity.y);
                    moving = true;
                }
                //Double Jump Logic
                if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
                {
                    isWallJumping = false;
                    if (xVelocity > -speed && Input.GetKey(KeyCode.LeftArrow))
                    {
                        rb.velocity = new Vector2(-speed, jumpSpeed);
                    }
                    else if (xVelocity < speed && Input.GetKey(KeyCode.RightArrow))
                    {
                        rb.velocity = new Vector2(speed, jumpSpeed);
                    }
                    else
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
                    }
                    jumpCount++;
                }
                //Dash Logic
                //if (Input.GetKeyDown(KeyCode.LeftShift) && dashActive)
                //{
                //    dashActive = false;
                //    if (facingRight)
                //    {
                //        transform.Translate(Vector3.right * dashDistance);
                //    }
                //    else
                //    {
                //        transform.Translate(Vector3.left * dashDistance);
                //    }
                //    Invoke("activateDash", 5);
                //    GameObject.FindGameObjectWithTag("DashTimer").GetComponent<DashCooldown>().active = false;
                //    GameObject.FindGameObjectWithTag("DashTimer").GetComponent<DashCooldown>().timenew = 5.0f;
                //}
            }
        }
        //Facing Forward Logic
        xVelocity = rb.velocity.x;

        if (xVelocity > 0 && !facingRight)
            flip();
        else if (xVelocity < 0 && facingRight)
            flip();
    }

    void FixedUpdate()
    {
       
    }

    void throwSnowball(int ySpeed, int xSpeed, float moveUp, float moveRight)
    {
        GameObject SpawnShuriken = Instantiate(Shuriken, transform.position + transform.up * moveUp + transform.right * moveRight, transform.rotation) as GameObject;
        SpawnShuriken.GetComponent<Shuriken>().ySpeed = ySpeed;
        SpawnShuriken.GetComponent<Shuriken>().xSpeed = xSpeed;
        AudioManager.instance.PlaySound("Throwing", transform.position);
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void flipY()
    {
        Vector3 theScale = transform.localScale;
        theScale.y *= -1;
        transform.localScale = theScale;
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Death")
        {
            lives--;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isWallJumping = false;
        anim.SetBool("idle", true);
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Death")
        {
            lives--;
        }

        if (collision.gameObject.tag == "Platform" || collision.gameObject.tag == "Finish")
        {
            transform.parent = collision.transform;
            rb.velocity = new Vector2(0, 0);
        }

        
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            isGrounded = true;
            jumpCount = 0;
        }
        if (collision.gameObject.tag == "Wall")
        {
            onWall = true;
            jumpCount = 1;
        }

        if(collision.gameObject.tag == "Ceiling")
        {
            isOnCeiling = true;
            jumpCount = 1;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform")
        {
            anim.SetBool("walking", false);
            anim.SetBool("running", false);
            isGrounded = false;
            jumpCount = 1;
        }
        if (collision.gameObject.tag == "Wall")
        {
            onWall = false;
            if(!isWallJumping)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
            } else
            {
                Invoke("WallJump", 1);
            }
            
        }
        if (collision.gameObject.tag == "Platform")
        {
            transform.parent = null;
        }
        if (collision.gameObject.tag == "Ceiling")
        {
            isOnCeiling = false;
            if (isCeilingDashing)
            {
                flipY();
                flip();
                rb.velocity = new Vector2(rb.velocity.x * 2 / 3, 0);
            }
            isCeilingDashing = false;
        }
    }

    private void WallJump()
    {
        isWallJumping = false;
    }
}
