using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float boundary = 20.0f; 
    public float speed = 10.0f;
    public float horizontalInput;

    public float zMin;
    public float zMax;
    public float verticalImput;

    public Transform projectileSpawnPoint;

    public GameObject projectilePrefab;

    void Update()
    {
        // Move the Player
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed);
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed);
        // Mathf.Clamp uses the x pos as the comparing value, and the "boundary"s as the min-max values (i.e the border).
        // So when x is between min and max, x = x. But if x < min, x = min. And if x > max, x = max.
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -boundary, boundary), transform.position.y, transform.position.z);
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.Clamp(transform.position.z, zMin, zMax));

    if (Input.GetKeyDown(KeyCode.Space))
    {
        // Launch a projectile from the player
        Instantiate(projectilePrefab, projectileSpawnPoint.position, projectilePrefab.transform.rotation);
    }

    }

}
