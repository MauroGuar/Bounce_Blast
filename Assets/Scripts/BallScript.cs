using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] static float rotationSpeed = -10;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
    }
    void FixedUpdate()
    {
        spriteRenderer.transform.Rotate(new Vector3(0,0,1) * rotationSpeed);
    }

    public static void changeRotation() {
        rotationSpeed *= -1;
    }
    public static void resetRotation() {
        rotationSpeed = -Mathf.Abs(rotationSpeed);
    }
}

