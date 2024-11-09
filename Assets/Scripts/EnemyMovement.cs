using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] public CircleCollider2D headColliderLeft;
    [SerializeField] public CircleCollider2D headColliderRight;
    [SerializeField] private float movementAmplitude = 5;
    [SerializeField] private float movementPeriod = 1;
    private GameObject Anchor;
    private float value;
    private float valueat;
    public Vector2 movement;
    private Transform tf;
    private Enemy enemy;
    private bool defeated = false;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    public void OnDefeat()
    {
        valueat = 0;
        defeated = true;
    }
    private void FixedUpdate()
    {
        if (!defeated)
        {
            value = value + Time.fixedDeltaTime;
            transform.localPosition = Mathf.Sin(value * movementPeriod) * Vector2.right * movementAmplitude;
            Vector2 movement = transform.localPosition;
            if (movement.x < -movementAmplitude + 0.01)
            {
                spriteRenderer.flipX = true;
                enemy.AttackForce.x = -1;
                headColliderLeft.enabled = false;
                headColliderRight.enabled = true;
            }
            if (movement.x > movementAmplitude - 0.01)
            {
                spriteRenderer.flipX = false;
                enemy.AttackForce.x = 1;
                headColliderRight.enabled = false;
                headColliderLeft.enabled = true;
            }
        }
        if (defeated)
        {
            spriteRenderer.flipX = false;
            valueat = valueat + Time.fixedDeltaTime;
            transform.localPosition = new Vector2 (transform.localPosition.x-(valueat * Vector2.right).x, (valueat * Vector2.right * 5).y);
        }
    }
}
