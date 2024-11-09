using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfAfterNeut : MonoBehaviour
{
    private float value;
    private Vector2 aftertf = new Vector2(0, -2.5f);
    [SerializeField] public GameObject Anchor;

    private void Start()
    {
        Anchor.transform.position = new Vector2(Anchor.transform.position.x, aftertf.y);
    }
    private void FixedUpdate()
    {
        value = value + Time.fixedDeltaTime;
        transform.localPosition = value * Vector2.left * 5;
    }
}
