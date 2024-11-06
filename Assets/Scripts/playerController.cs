using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class playerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    Vector2 moveInput;
    public bool IsMoving { get; private set; }

    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        Debug.Log($"OnMove called. Move Input: {moveInput}, IsMoving: {IsMoving}");
    }

}
