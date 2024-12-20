using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformMovement : MonoBehaviour
{
    private float value;

    private void FixedUpdate()
    {
        value = value + Time.fixedDeltaTime;
        transform.localPosition = Mathf.Sin(value) * Vector2.right*5;
    }
}
