using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _rb;
    SpriteRenderer _sr;
    ForceMode2D m_ForceMode;

    public static int selection;

    public Joystick joystick;

    public Animator animator;
    public Sprite sprite;

    public static int jumpsLeft = 1;

    public float baseSpeed = 6f;
    public float slowedDownSpeed = 3f;
    public float spedUpSpeed = 10f;

    public int baseJump = 10;
    public int jumpSpeedUp = 10;

    private float currentRunSpeed = 0f;
    private int currentJumpSpeed = 0;

    float horizontalMove = 0f;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    private Vector3 m_Velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        currentRunSpeed = baseSpeed;
        currentJumpSpeed = baseJump;
    }

    // Update is called once per frame
    void Update()
    {
        //Input.GetAxis("Horizontal")
        horizontalMove =  joystick.Horizontal * currentRunSpeed;
        print(joystick.Horizontal);
        for (int i = 0; i< Input.touchCount; i++)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.touches[i].position);
            Debug.DrawLine(Vector3.zero, touchPosition, Color.red);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (jumpsLeft > 0)
            {
                animator.SetBool("isJumping", true);
                m_ForceMode = ForceMode2D.Impulse;//try changing this
                //_rb.AddForce(Vector2.up * currentJumpSpeed, m_ForceMode);
                _rb.velocity = new Vector3(0, currentJumpSpeed, 0);
                jumpsLeft--;
            }
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 targetVelocity = new Vector2(-horizontalMove, _rb.velocity.y);
            _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            _sr.flipX = true;
            animator.SetBool("isCrouching", false);
            // _rb.AddForce(Vector2.left * currentRunSpeed);
        }
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 targetVelocity = new Vector2(horizontalMove, _rb.velocity.y);
            _rb.velocity = Vector3.SmoothDamp(_rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);
            _sr.flipX = false;
            animator.SetBool("isCrouching", false);
        }
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isCrouching", true);
        }
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, -transform.up, .7f);
            //Debug.DrawRay(transform.position, -transform.up * 0.7f);
            for (int i = 0; i < hits.Length; i++)
            {
                if (hits[i].collider.gameObject.layer == LayerMask.NameToLayer("Ground"))
                {
                    animator.SetBool("isJumping", false);
                    jumpsLeft = 1;
                }
            }
        }
        if (collision.gameObject.tag == "SpeedUp")
        {
            currentRunSpeed = spedUpSpeed;
        }
        if (collision.gameObject.tag == "Normal")
        {
            currentRunSpeed = baseSpeed;
        }
        if (collision.gameObject.tag == "SpeedDown")
        {
            currentRunSpeed = slowedDownSpeed;
        }
        if (collision.gameObject.tag == "HigherJump")
        {
            currentJumpSpeed = jumpSpeedUp; 
        }
        if (collision.gameObject.tag == "TripleJump")
        {
            jumpsLeft = 3;
        }
    }

}