using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed = 1;
    [SerializeField] float jumpForce = 5;
    [SerializeField] int totalJumps = 1;

    int availableJumps;

    private Rigidbody2D _rigidbody;
    Animator animator;
    [SerializeField] Transform groundCheckCollider;

    [SerializeField] float groundCheckRadius = 0.2f;
    private float _horizontalValue;
    bool _facingRight = true;
    [SerializeField] LayerMask groundLayer;

    bool isRunning;
    public float runSpeedModifier = 2f;
    bool isGrounded;

    public static CharacterMovement instance;
    private bool _cant_move = false;
    public float min_y_velocity = 0;

    public bool isTouchingSpike;
    public float jumpForceInSpikes = 0.5f;
    public bool fallDamage = true;
    public bool multipleJump = false;

    [SerializeField] GameObject damageEffect;

    private bool flashlightAvailable = false;
    private bool flashOn = false;
    [SerializeField] GameObject flashlight;

    void Awake()
    {
        instance = this;

        availableJumps = totalJumps;

        _rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public void DontMove(bool no_move)
    {
        if (no_move)
        {
            _rigidbody.constraints = RigidbodyConstraints2D.FreezePositionX;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            _cant_move = true;
            animator.SetFloat("x_velocity", Mathf.Abs(0));
        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints2D.None;
            _rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            _cant_move = false;
        }
    }
    
    void Update()
    {
        if (!_cant_move)
        {
            //Store the horizontal value
            _horizontalValue = Input.GetAxisRaw("Horizontal");

            //If shift, isRunning or not
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isRunning = true;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                isRunning = false;
            }
            if (Input.GetButtonDown("Jump"))
            {
                Jump();
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (flashlightAvailable)
                {
                    Flashlight();
                }
            }
            animator.SetFloat("y_velocity", _rigidbody.velocity.y);
        }
        if(min_y_velocity > _rigidbody.velocity.y)
        {
            min_y_velocity = _rigidbody.velocity.y;
        }
        TouchingSpikes();
    }

    private void Flashlight()
    {
        if (flashOn)
        {
            flashlight.SetActive(false);
            flashOn = false;
        }
        else if(!flashOn)
        {
            flashlight.SetActive(true);
            flashOn = true;
        }
    }

    public void AvailableFlashlight()
    {
        flashlightAvailable = true;
    }

    private void FixedUpdate()
    {
        GroundCheck();

        if(!_cant_move)
            Move(_horizontalValue);
    }
    public void TouchingSpikes()
    {
        if (isTouchingSpike)
        {
            _rigidbody.AddForce(new Vector2(_rigidbody.velocity.x, jumpForceInSpikes), ForceMode2D.Impulse);
        }
    }

    public void DamageEffect()
    {
        damageEffect.SetActive(true);
        Instantiate(damageEffect, transform.position, Quaternion.identity);
    }

    public void ChangeJumpAmount(int count)
    {
        totalJumps = count;
        availableJumps = totalJumps;
    }

    void GroundCheck()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (colliders.Length > 0) {
            isGrounded = true;

            if (!wasGrounded)
            {
                availableJumps = totalJumps;
                multipleJump = false;
            }

            if (!fallDamage)
            {
                min_y_velocity = 0;
                fallDamage = true;
            }
            TakeFallDamage();
            min_y_velocity = 0;
        }

        animator.SetBool("jumping", !isGrounded);
    }

    void TakeFallDamage()
    {
        if (min_y_velocity < -15) {
            {
                HealthSystem.instance.Damage((-(int)(min_y_velocity) * 2) + 1);
            }
        }
    }

    public void DamageAnimation(bool val)
    {
        animator.SetBool("isHurt", val);
    }

    void Jump()
    {
        if (isGrounded)
        {
            multipleJump = true;
            availableJumps--;

            _rigidbody.velocity = Vector2.up * jumpForce;
            animator.SetBool("jumping", true);
        }
        else
        {
            if (multipleJump && availableJumps > 0)
            {
                availableJumps--;

                _rigidbody.velocity = Vector2.up * jumpForce;
                animator.SetBool("jumping", true);
            }
        }
    }

    void Move(float dir)
    {
        

        #region Move & Run

        float x_val = dir * movementSpeed * 100 * Time.fixedDeltaTime;
        if (isRunning)
            x_val *= runSpeedModifier;
        Vector2 targetVelocity = new Vector2(x_val, _rigidbody.velocity.y);
        _rigidbody.velocity = targetVelocity;

        if(_facingRight && dir < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _facingRight = false;
        }
        else if (!_facingRight && dir > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            _facingRight = true;
        }
        
        animator.SetFloat("x_velocity", Mathf.Abs(_rigidbody.velocity.x));

        #endregion
    }
}
