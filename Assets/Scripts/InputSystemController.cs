using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{
    [SerializeField] private AudioSource Balalaika;

    public void OnStrum()
    {
        Debug.Log("Strummed!");
        Balalaika.Play();

    }
    private void FixedUpdate()
    {

    }
}