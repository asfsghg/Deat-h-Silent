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
        
        int number = Random.Range(0, 1000); 
        PhotonNetwork.NickName = $"Player {number}";
    }
    
    public override void OnJoinedLobby()
    {
        windowsManager.OpenLayout(WindowsConstant.Main_Menu_Panel);
        playerNameInputField.text = PhotonNetwork.NickName;
        Debug.Log("Joined Lobby");
    }

    public void CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions
        {
            IsVisible = true,
            IsOpen = true,
            MaxPlayers = 15
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
}
