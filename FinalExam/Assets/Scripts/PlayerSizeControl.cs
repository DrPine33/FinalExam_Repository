using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSizeControl : MonoBehaviour
{
    public Slider playerSizeSlider; // Reference to the PlayerSizeSlider

    private Transform playerTransform; // Reference to the player's transform component

    private void Start()
    {
        // Assuming the player object is tagged as "Player"
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            playerTransform = playerObject.transform;
        }

        // Add listener for the slider's value change event
        playerSizeSlider.onValueChanged.AddListener(ChangePlayerSize);
    }

    private void ChangePlayerSize(float newSize)
    {
        // Limit the size within the range of 1 to 2
        float clampedSize = Mathf.Clamp(newSize, 1f, 2f);

        // Update the player's scale
        playerTransform.localScale = new Vector3(clampedSize, clampedSize, clampedSize);
    }
}
