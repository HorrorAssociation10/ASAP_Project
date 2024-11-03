using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CircleCollider2D headColliderLeft;
    [SerializeField] private CircleCollider2D headColliderRight;
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
        transform.localPosition = Mathf.Sin(value) * Vector2.right * 5;
        Vector2 movement = transform.localPosition;
        if (movement.x < -4.99)
        {
            spriteRenderer.flipX = true;
            enemy.AttackForce.x = -1;
            headColliderLeft.enabled = false;
            headColliderRight.enabled = true;
        }
        if (movement.x > 4.99)
        {
            spriteRenderer.flipX = false;
            enemy.AttackForce.x = 1;
            headColliderRight.enabled = false;
            headColliderLeft.enabled= true;
        }
    }
}
