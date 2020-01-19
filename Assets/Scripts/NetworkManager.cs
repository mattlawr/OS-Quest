﻿using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour
{

    NetworkCallbacks callbacks = null;

    [SerializeField] Text text;
    // Start is called before the first frame update

    private void Awake()
    {
        callbacks = GetComponent<NetworkCallbacks>();
    }
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Joins a room by name
    public void joinServer(string name)
    {
        if (callbacks.isConnectedToMaster)
        {
             PhotonNetwork.JoinRoom(name);
        }
        else
        {
            Debug.Log("Cannot Join Server: Not Connected");
        }
    }

    // Creates a room by name
    public void createServer(string name)
    {
        if (callbacks.isConnectedToMaster)
        {
            PhotonNetwork.CreateRoom(name);
        }
        else
        {
            Debug.Log("Cannot Create Server: Not Connected");
        }
    }


    //Refresh player list
    public void refreshPlayers()
    {
        string playerList = "";
        foreach (Photon.Realtime.Player player in PhotonNetwork.PlayerList)
        {
            playerList += player.UserId + "\n";
        }
        text.text = playerList;
    }

}