using System.IO;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance; // null
    public Button LeaveButton;
    
    private void Awake()
    {
        Instance = this;
    }
    
    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }
    
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
      //  Debug.LogFormat("Player {0} joined the room", newPlayer.NickName);
        
    }

    public override void OnJoinedRoom()
    {
       // Debug.LogFormat("Player {0} joined the room", PhotonNetwork.LocalPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
       // Debug.LogFormat("Player {0} left the room", otherPlayer.NickName);
    }
}
