using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    Vector2 moveInput;

    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving { get
        {
            return _isMoving;
        } 
        private set
        {
            _isMoving = value;
            animator.SetBool("isMoving?", value);
        } 
    }

    [SerializeField]
    private bool _isRunning = false;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
            animator.SetBool("isRunning?", value);
        }
    }

    public bool _isFacingRight = true;

    public bool IsFacingRight { get { return _isFacingRight;}  private set {
        if(_isFacingRight != value)
        {
            transform.localScale *= new Vector2(-1, 1);
        }

        _isFacingRight = value;
    }}

    Rigidbody2D rb;
    Animator animator; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        //Debug.Log($"Move Input: {moveInput}, Velocity: {new Vector2(moveInput.x * walkSpeed, rb.velocity.y)}");
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        //* Time.fixedDeltaTime
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
        //Debug.Log($"OnMove called. Move Input: {moveInput}, IsMoving: {IsMoving}");

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            //Face the right
            IsFacingRight = true; 
        }
        else if(moveInput.x < 0 && IsFacingRight)
        {
            //Face the left
            IsFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        IsRunning = context.ReadValueAsButton();{}
        {
            if (context.started)
            {
                IsRunning = true;
            } else if (context.canceled)
            {
                IsRunning = false;
            }


        }
    }
}
