using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CircleCollider2D headColliderLeft;
    [SerializeField] private CircleCollider2D headColliderRight;
    [SerializeField] private float movementAmplitude = 5;
    [SerializeField] private float movementPeriod = 1;
    private float value;
    private Vector2 movement;
    private Transform tf;
    private Enemy enemy;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void FixedUpdate()
    {
        value = value + Time.fixedDeltaTime;
        transform.localPosition = Mathf.Sin(value*movementPeriod) * Vector2.right * movementAmplitude;
        Vector2 movement = transform.localPosition;
        if (movement.x < -movementAmplitude+0.01)
        {
            spriteRenderer.flipX = true;
            enemy.AttackForce.x = -1;
            headColliderLeft.enabled = false;
            headColliderRight.enabled = true;
        }
        if (movement.x > movementAmplitude-0.01)
        {
            spriteRenderer.flipX = false;
            enemy.AttackForce.x = 1;
            headColliderRight.enabled = false;
            headColliderLeft.enabled= true;
        }
    }
}
