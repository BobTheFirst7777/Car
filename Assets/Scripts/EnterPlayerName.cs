using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnterPlayerName : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private Button continueHost;
    [SerializeField] private Button continueClient;

    public static string displayName; //{ get; private set; }

    private void Start()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            string defaultName = PlayerPrefs.GetString("PlayerName");
            nameInput.text = defaultName;
        }
    }

    public void saveName()
    {
        displayName = nameInput.text;
        PlayerPrefs.SetString("PlayerName", displayName);
    }


}
