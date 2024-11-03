using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    [SerializeField] private AudioSource Balalaika;
    [SerializeField] public bool TookObject = false;

    public void OnStrum()
    {
        Debug.Log("Strummed!");
        Balalaika.Play();

    }
    public void OnTake()
    {
        TookObject = true;
        Debug.Log("F Pressed");
    }
    private void FixedUpdate()
    {
        
    }
}