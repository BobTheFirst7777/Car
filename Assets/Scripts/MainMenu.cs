using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private NetworkManagerLobby networkManager;
    
    public void hostLobby()
    {
        networkManager.StartHost();
    }


}
