using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 40.0f;
    public float spin = 0;

    // Update is called once per frame
    void Update()
    {
        // Move the gameObject in the given directions each frame
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        transform.Rotate(Vector3.forward * Time.deltaTime * spin);
    }
}
