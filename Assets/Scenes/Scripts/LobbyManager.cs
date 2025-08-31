using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    public static LobbyManager Instance;
    
    [SerializeField] private TMP_InputField playerNameInputField;

    [Header("Room Settings")]
    [SerializeField] private TMP_InputField roomNameInputField;
    [SerializeField] private TMP_Text roomNameText;

    [Header("Room List Settings")]
    [SerializeField] private Transform transformRoomList;
    [SerializeField] private GameObject roomButtonPrefab;

    [Header("Player List Settings")]
    [SerializeField] private Transform transformPlayerList;
    [SerializeField] private GameObject playerNamePrefab;

    [SerializeField] private GameObject startGameButton;
    
    [SerializeField] private WindowsManager windowsManager;
    
    
    
    
    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    { 
        PhotonNetwork.JoinLobby(); 
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    
    public override void OnJoinedLobby()
    {
        windowsManager.OpenLayout(WindowsConstant.Main_Menu_Panel);

        Debug.Log("Joined Lobby");
    }
    

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform obj in transformRoomList)
        {
            Destroy(obj.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            
        }
    }
}
