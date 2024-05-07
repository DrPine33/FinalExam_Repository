using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetRotation : MonoBehaviour
{
    public float rotationSpeed = 45f; // degrees per second



    // this is the real final exam for sp ring 2024
    void Update()
    {
        // rotate around the vertical axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        // rotate around the horizontal axis
        transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime);
    }

    public int points = 1; // Points awarded for destroying this target

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object colliding with the target has a Rigidbody (assuming the player has one)
        if (collision.rigidbody != null)
        {
            // Destroy this target GameObject
            Destroy(gameObject);

            // Increment the player's points
            ScoreControl.instance.AddPoints(points);
        }
    }
}
