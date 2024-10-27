using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]

public class MovementController : MonoBehaviour
{
    [SerializeField]
    private float Speed = 5;
    [SerializeField]
    private float JumpSpeed = 5;

    [Header("Gravity Settings")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private CircleCollider2D groundCollider;

    private Rigidbody2D body;
    private ContactFilter2D groundFilter;

    private bool isJump;
    private Vector2 movementInput;
    private bool isGrounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    private void Start()
    {
        groundFilter.SetLayerMask(groundLayer);
        groundFilter.useLayerMask = true;
        groundFilter.useTriggers = false;
    }

    public void OnMove(InputValue input)
    {
        movementInput = input.Get<Vector2>().normalized;
    }
    private void OnJump()
    {
        isJump = true;
    }

    private void FixedUpdate()
    {
        GroundCheck();
        if (isJump && isGrounded)
        {
            body.AddForce(JumpSpeed * Vector2.up, ForceMode2D.Impulse);
        }
        isJump = false;
        
        if (isGrounded)
        {
            body.AddForce(movementInput * Vector2.right * Speed);
        }
    }
    private void GroundCheck()
    {
        Collider2D[] collides = new Collider2D[16];
        var count = groundCollider.OverlapCollider(groundFilter, collides);
        isGrounded = count > 0;
    }
}
