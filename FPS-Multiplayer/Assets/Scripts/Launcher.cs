using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public InputField RoomName;

    public string PlayerPrefabName;
    private bool connectedToMaster;
    private bool joinedRoom;
    public void ConnectToMaster()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = "Alpha";
    }
    
    
    public void CreateRoom()
    {
        if (!connectedToMaster || joinedRoom) return;
        PhotonNetwork.CreateRoom(RoomName.text, 
            new RoomOptions() {MaxPlayers = 16},
            TypedLobby.Default);
    }


    public void JoinRoom()
    {
        if (!connectedToMaster  || joinedRoom) return;
        PhotonNetwork.JoinRoom(RoomName.text);

    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        connectedToMaster = true;
    }


    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        joinedRoom = true;
    }


    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Joined Room");
        PhotonNetwork.Instantiate(PlayerPrefabName, Vector3.zero, Quaternion.identity);
    }
}
