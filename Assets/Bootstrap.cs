using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Canvas))]

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private string mainScene;

    public IEnumerator Start()
    {
        yield return new WaitForSeconds(5f);
        yield return SceneManager.LoadSceneAsync(mainScene);
    }
}
