using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class The : MonoBehaviour
{
    public static The Instance { get; private set; }

    [SerializeField] private GameObject characterPrefab1;
    [SerializeField] private GameObject characterPrefab2;
    [SerializeField] private GameObject characterPrefab3;

    [SerializeField] public string Checkpoint = "PreHistory";

    private void Start()
    {
        Instance ??= this;

        if (Instance == this)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void FetchACheckpoint(string SceneName)
    {
        Checkpoint = SceneName;
    }
}
