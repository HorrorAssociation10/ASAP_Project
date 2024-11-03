using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Spikes : MonoBehaviour
{
    [SerializeField] private int DamageScore = -1;
    private Animator plAnimator;
    private float timer = 1;

    private LevelManager levelManager;

    public void SetLevelManager(LevelManager levelManager)
    {
        this.levelManager = levelManager;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        timer += Time.deltaTime;
        if (collision.TryGetComponent<Player>(out var player)&&timer>=1)
        {
            Debug.Log("Collides!");
            plAnimator = collision.GetComponent<Animator>();
            Debug.Log($"{plAnimator.GetType()} Detected!");
            levelManager.UpdateScore(DamageScore);
            plAnimator.SetTrigger("Hurt");
            Debug.Log("Health decreased by 1");
            timer = 0;
        }
    }
    private void OnTriggerExit2D()
    {
        timer = 1;
    }
}
