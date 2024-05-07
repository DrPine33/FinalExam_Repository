using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerColorControl : MonoBehaviour
{
    public Dropdown colorDropdown;
    public Renderer playerRenderer;

    private Color[] colorOptions = { Color.clear,Color.green, Color.blue, Color.red }; // Array of color options

    private void Start()
    {
        // Add listener for the dropdown's value change event
        colorDropdown.onValueChanged.AddListener(ChangePlayerColor);
    }

    private void ChangePlayerColor(int colorIndex)
    {
        // Check if the index is within the range of color options
        if (colorIndex >= 0 && colorIndex < colorOptions.Length)
        {
            // Change the player's color to the selected color
            playerRenderer.material.color = colorOptions[colorIndex];
        }
        else
        {
            Debug.LogError("Invalid color index!");
        }
    }
}
