using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{

    [SerializeField] private TMP_InputField playerNameInputField;


    [Header("Room Settings")]
    [SerializeField] private TMP_InputField roomNameInputFile;
    [SerializeField] private TMP_Text roomNameText;

    [Header("Room List Settings")]
    [SerializeField] private Transform transformRoomList;
    [SerializeField] private GameObject roomButtonPrefab;

    [Header("Player List Settings")]
    [SerializeField] private Transform transformPlayerList;
    [SerializeField] private GameObject prlayerNamePrefab;

    [SerializeField] private GameObject stratGameButtun;




    [SerializeField] private WindowsManager WindowsManager;
    void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;

        int number = Random.Range(0, 10000);
        PhotonNetwork.NickName = $"Player {number}";
    }
    public override void OnJoinedLobby()
    {
        WindowsManager.OpenLayout(WindowsConstant.Main_Menu_Panel);
        playerNameInputField.text = PhotonNetwork.NickName;
        Debug.Log("Joined Lobby");

    }
    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions()
        {
            IsOpen = true,
            IsVisible = true,
            MaxPlayers = 5
        };
        PhotonNetwork.CreateRoom("RoomName", roomOptions);
    }
    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    void Update()
    {
        
    }
}
