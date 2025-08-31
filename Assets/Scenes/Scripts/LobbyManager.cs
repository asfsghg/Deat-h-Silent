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
    



    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (Transform obj in transformRoomList)
        {        
            
            
            Destroy(obj.gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            GameObject obj = Instantiate(roomButtonPrefab,transformRoomList);
            RoomListItem roomItem = obj.GetComponent<RoomListItem>();
            roomItem.SetRoomInfo(roomList[i]);
        }
    }
    
    public void JoinRoom(RoomInfo roomInfo)
    {
     PhotonNetwork.JoinRoom(roomInfo.Name);
    }

    public override void OnJoinedRoom()
    {
        windowsManager.OpenLayout(WindowsConstant.Game_Room_Panel);
            startGameButton.SetActive(PhotonNetwork.IsMasterClient);
            
            roomNameText.text = PhotonNetwork.CurrentRoom.Name;
            
            Player [] players = PhotonNetwork.PlayerList;

            foreach (Transform trn in transformPlayerList)
            {
                Destroy(trn.gameObject);
            }

            for (int i = 0; i < players.Length; i++)
            {
                GameObject obj = Instantiate(playerNamePrefab, transformPlayerList);
                PlayerListItem playerItem = obj.GetComponent<PlayerListItem>();
                playerItem.SetPlayer(players[i]);
            }
       
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        GameObject obj = Instantiate(playerNamePrefab, transformPlayerList);
        PlayerListItem playerItem = obj.GetComponent<PlayerListItem>();
        playerItem.SetPlayer(newPlayer);
    }

    public override void OnLeftRoom()
    {
        windowsManager.OpenLayout(WindowsConstant.Find_Rooms_Panel);
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(roomNameInputField.text)) return;
        roomNameText.text = roomNameInputField.text;
        PhotonNetwork.CreateRoom(roomNameText.text);
    }

    public void StartGameLevel(int levelIndex)
    {
        PhotonNetwork.LoadLevel(levelIndex);
    }
}
