using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance; // null
    
    [SerializeField] private GameObject playerPrefab;
    
    [SerializeField] private Transform[] playerSpawnPoints;
    
    private void Awake()
    {
        Instance = this;
        
        int index = Random.Range(0, playerSpawnPoints.Length);
        Vector3 spawnPosition = playerSpawnPoints[index].position;

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, 
                Quaternion.identity);
        }
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        SceneManager.LoadScene(0);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} joined the room", newPlayer.NickName);
    }

    public override void OnJoinedRoom()
    {
        Debug.LogFormat("Player {0} joined the room", PhotonNetwork.LocalPlayer.NickName);
        
        int index = Random.Range(0, playerSpawnPoints.Length);
        Vector3 spawnPosition = playerSpawnPoints[index].position;
        
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, 
            Quaternion.identity);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} left the room", otherPlayer.NickName);
    }
}
