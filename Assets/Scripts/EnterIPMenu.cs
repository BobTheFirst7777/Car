using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnterIPMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerLobby networkManager;

    [SerializeField] private TMP_InputField ipInputField;
    [SerializeField] private GameObject menuUI;
    [SerializeField] private Button joinButton;

    private void OnEnable()
    {
        NetworkManagerLobby.OnClientConnencted += HandleClientConnected;
        NetworkManagerLobby.OnClientDisconnected += HandleClientDisconnected;
    }

    private void OnDisable()
    {
        NetworkManagerLobby.OnClientConnencted -= HandleClientConnected;
        NetworkManagerLobby.OnClientDisconnected -= HandleClientDisconnected;
    }


    public void joinLobby()
    {
        string ip = ipInputField.text;
        networkManager.networkAddress = ip;
        networkManager.StartClient();

        joinButton.interactable = false;
    }

    private void HandleClientConnected()
    {
        gameObject.SetActive(false);
        menuUI.SetActive(false);

        joinButton.interactable = true;
    }

    private void HandleClientDisconnected()
    {
        joinButton.interactable = true;
    }


}
