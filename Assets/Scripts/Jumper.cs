using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float JumperPower = 12.5f;
    [SerializeField] private Vector2 jumpVector = new Vector2(0, 1);
    /*[SerializeField] private int PickupScore = 1;
    [SerializeField] private bool ObjectTaken;

    private LevelManager levelManager;

    public void SetLevelManager(LevelManager levelManager)
    {
        this.levelManager = levelManager;
    }*/
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player) )
        {
            //levelManager.UpdateScore(PickupScore);
            var body = collision.GetComponent<Rigidbody2D>();
            body.velocity = jumpVector;
            body.AddForce(JumperPower*jumpVector, ForceMode2D.Impulse);
            Debug.Log("Jumper Triggered!");
        }
    }
}
