using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class NetworkManagerLobby : NetworkManager
{
    [SerializeField] private Scene menuScene;

    [SerializeField] private RoomPlayer roomPlayerPrefab;

    public static event Action OnClientConnencted;
    public static event Action OnClientDisconnected;

    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        OnClientConnencted?.Invoke();
    }

    public override void OnClientDisconnect(NetworkConnection conn)
    {
        base.OnClientDisconnect(conn);

        OnClientDisconnected?.Invoke();
    }

    public override void OnServerConnect(NetworkConnection conn)
    {
        if (numPlayers >= maxConnections)
        {
            conn.Disconnect();
            return;
        }

    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        if(SceneManager.GetActiveScene() == menuScene)
        {
            RoomPlayer roomPlayerInstance = Instantiate(roomPlayerPrefab);

            NetworkServer.AddPlayerForConnection(conn, roomPlayerInstance.gameObject);
        }
    }























}
