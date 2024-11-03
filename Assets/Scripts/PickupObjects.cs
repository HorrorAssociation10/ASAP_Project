using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickupObjects : MonoBehaviour
{
    [SerializeField] private int PickupScore = 1;
    [SerializeField] private bool ObjectTaken;

    private LevelManager levelManager;

    public void SetLevelManager(LevelManager levelManager)
    {
        this.levelManager = levelManager;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        var InpSys = collision.GetComponent<InputSystemController>();
        if (collision.TryGetComponent<Player>(out var player)&&InpSys.TookObject)
        {
            levelManager.UpdateScore(PickupScore);
            gameObject.SetActive(false);
            Debug.Log("Health increased by 1");
            InpSys.TookObject = false;
        }
    }
}
