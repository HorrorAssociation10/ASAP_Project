using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    [SerializeField] private AudioSource Balalaika;
    [SerializeField] public bool TookObject = false;
    [SerializeField] public bool NearCheck = false;

    public void OnStrum()
    {
        Debug.Log("Strummed!");
        Balalaika.Play();

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