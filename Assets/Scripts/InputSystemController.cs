using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    [SerializeField] private AudioSource BalalaikaFail;
    [SerializeField] private AudioSource BalalaikaSuccess;
    [SerializeField] public bool TookObject = false;
    [SerializeField] public bool NearCheck = false;
    [SerializeField] public bool EnemyNeutralized = false;
    [SerializeField] public bool EnemyNearCheck = false;

    public void OnStrum()
    {
        if (EnemyNearCheck)
        {
            Debug.Log("Played successfully!");
            EnemyNeutralized = true;
            BalalaikaSuccess.Play();
        }
        else
        {
            Debug.Log("Strummed, but no enemies nearby");
            BalalaikaFail.Play();
        }

    }
    public void OnTake()
    { if (NearCheck)
        {
            TookObject = true;
        }
        else
            Debug.Log("F Pressed, but nothing happened");
    }
    private void FixedUpdate()
    {
        
    }
}