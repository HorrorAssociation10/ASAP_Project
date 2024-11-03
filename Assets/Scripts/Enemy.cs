using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int DamageScore = -1;
    [SerializeField] private Animator animator;
    public Vector2 AttackForce;

    private LevelManager levelManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetLevelManager(LevelManager levelManager)
    {
        this.levelManager = levelManager;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            var plAnimator = collision.GetComponent<Animator>();
            var plBody = collision.GetComponent<Rigidbody2D>();
            plBody.AddForce(Vector2.left * AttackForce.x * 500);
            plAnimator.SetTrigger("Hurt");
            animator.SetTrigger("Attack");
            levelManager.UpdateScore(DamageScore);
            Debug.Log("You have been bitten, -1 health points");
        }
    }
}
