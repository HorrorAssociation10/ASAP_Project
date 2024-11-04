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
    [SerializeField] private GameObject levelHudGameObject;
    [SerializeField] private GameObject cutsceneHudGameObject;
    [SerializeField] private List<GameObject> dialoguesList;
    [Header("Settings")]
    [SerializeField] private int DialoguesAmount;
    [SerializeField] private bool ChangeSceneOnFinish = false;
    [SerializeField] private PlayerInput actualPlayerInput;

    private int currentDialogue = 1;

    private readonly UICommandQueue commandQueue = new UICommandQueue();

    private void Start()
    {
        Debug.Log("Dialogs begin!");
        reloadButton.onClick.AddListener(() => commandQueue.TryEnqueueCommand(new ReloadCommand()));
        StartCoroutine(NextDialogue());
    }
    public void EngageDialogue()
    {
        commandQueue.TryEnqueueCommand(new EngageDialogueCommand());
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
                    case EngageDialogueCommand newone:
                        {
                            Debug.Log("Dialogue engaged!");
                            actualPlayerInput.SwitchCurrentActionMap("SwitchDialogues");
                            break;
                        }
                    case NextDialogueCommand nextone:
                        {
                            if (currentDialogue <= DialoguesAmount)
                            {
                                foreach (GameObject dialogue in dialoguesList)
                                {
                                    dialogue.SetActive(false);
                                }
                                dialoguesList[currentDialogue - 1].SetActive(true);
                            }
                            else
                            {
                                if (ChangeSceneOnFinish)
                                {
                                    SceneManager.LoadSceneAsync("Level1");
                                }
                                else
                                {
                                    levelHudGameObject.SetActive(true);
                                    cutsceneHudGameObject.SetActive(false);
                                    actualPlayerInput.SwitchCurrentActionMap("Player");
                                    foreach (GameObject dialogue in dialoguesList)
                                    {
                                        dialogue.SetActive(false);
                                    }
                                }

                            }
                            break;
                        }
                    default:
                        break;
                }
            }

            yield return null;
        }
    }
}
