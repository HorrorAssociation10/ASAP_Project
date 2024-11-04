using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueInitiator : MonoBehaviour
{
    [SerializeField] private GameObject calledDialogue;
    private CutsceneHUD hud;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            Debug.Log("Dialogue-initiating trigger entered!");
            calledDialogue.SetActive(true);
            hud = calledDialogue.GetComponent<CutsceneHUD>();
            hud.EngageDialogue();
        }
    }
}
