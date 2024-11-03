using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class CutsceneHUD : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Button reloadButton;
    [SerializeField] private List<GameObject> dialoguesList;
    private int currentDialogue = 1;

    private readonly UICommandQueue commandQueue = new UICommandQueue();

    private void Start()
    {
        Debug.Log("Dialogs begin!");
        reloadButton.onClick.AddListener(() => commandQueue.TryEnqueueCommand(new ReloadCommand()));
        StartCoroutine(NextDialogue());
    }
    private void OnNextDialogue()
    {
        ++currentDialogue;
        Debug.Log("Key pressed!");
        commandQueue.TryEnqueueCommand(new NextDialogueCommand());
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator NextDialogue()
    {
        while (true)
        {
            if (commandQueue.TryDequeueCommand(out var command))
            {
                switch (command)
                {
                    case NextDialogueCommand nextone:
                        {
                            switch (currentDialogue)
                            {
                                case 1:
                                    {
                                        foreach (GameObject dialogue in dialoguesList)
                                        {
                                            dialogue.SetActive(false);
                                        }
                                        dialoguesList[0].SetActive(true);
                                        break;
                                    }
                                case 2:
                                    {
                                        foreach (GameObject dialogue in dialoguesList)
                                        {
                                            dialogue.SetActive(false);
                                        }
                                        dialoguesList[1].SetActive(true);
                                        break;
                                    }
                                case 3:
                                    {
                                        foreach (GameObject dialogue in dialoguesList)
                                        {
                                            dialogue.SetActive(false);
                                        }
                                        dialoguesList[2].SetActive(true);
                                        currentDialogue = 998;
                                        break;
                                    }
                                case 999:
                                    {
                                        SceneManager.LoadSceneAsync("Level1");
                                        break;
                                    }
                                default:
                                    break;
                            }
                            break;
                        }
                }
            }

            yield return null;
        }
    }
}
