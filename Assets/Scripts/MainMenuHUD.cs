using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuHUD : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [Header("UI")]
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private Button reloadButton;
    [SerializeField] private Button newGameButton;

    private readonly UICommandQueue commandQueue = new UICommandQueue();

    private void Start()
    {
        Debug.Log("void Start executed");
        reloadButton.onClick.AddListener(() => commandQueue.TryEnqueueCommand(new ReloadCommand()));
        newGameButton.onClick.AddListener(() => commandQueue.TryEnqueueCommand(new NewGameCommand()));
        StartCoroutine(UpdateTask());
    }
    private void OnDestroy()
    {
        StopAllCoroutines();
    }

    private IEnumerator UpdateTask()
    {
        while (true)
        {
            if (commandQueue.TryDequeueCommand(out var command))
            {
                switch (command)
                {
                    case ReloadCommand _:
                        {
                            var currentScene = SceneManager.GetActiveScene();
                            SceneManager.LoadSceneAsync(currentScene.name);
                            break;
                        }
                    case NewGameCommand newgame:
                        {
                            SceneManager.LoadSceneAsync("PreHistory");
                            break;
                        }
                    default:
                        {
                            Debug.Log($"Unknown Command {command.GetType()}");
                            break;
                        }
                }
            }

            yield return null;
        }
    }
}
