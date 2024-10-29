using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObjects : MonoBehaviour
{
    [SerializeField] private int PickupScore = 1;

    private LevelManager levelManager;

    public void SetLevelManager(LevelManager levelManager)
    {
        this.levelManager = levelManager;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            levelManager.UpdateScore(PickupScore);
            gameObject.SetActive(false);
            Debug.Log("Health increased by 1");
        }
    }
}
