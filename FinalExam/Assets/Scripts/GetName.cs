using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetName : MonoBehaviour
{
    public Text nameText;
    void Start()
    {
        string Name = PlayerPrefs.GetString("Player", "");
        nameText.text = Name;
    }

}
