using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public static GameManager Instance;
    [SerializeField] private GameObject playerPrefab;
    
    [SerializeField] private Transform[] playerSpawnPoints;
    void Awake()
    {
        Instance = this;
        int index = Random.Range(0, playerSpawnPoints.Length);
        Vector3 spawnPos = playerSpawnPoints[index].position;

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity);
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
        Debug.LogFormat("Player {0} has entered the room}",newPlayer.NickName);
    }

    public override void OnJoinedRoom()
    {
        Debug.LogFormat("Player {0} has entered the room}",PhotonNetwork.LocalPlayer.NickName);
        
        int index = Random.Range(0, playerSpawnPoints.Length);
        Vector3 spawnPos = playerSpawnPoints[index].position;

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity);
        }
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.LogFormat("Player {0} has left the room",otherPlayer.NickName);
    }

}
