using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
     public static GameManager instance;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform[] playerSpawnPoint;


    private void Awake()
    {
        instance = this;

        int index = Random.Range(0, playerSpawnPoint.Length);
        Vector3 spawnPosition = playerSpawnPoint[index].position;

        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
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

        int index = Random.Range(0, playerSpawnPoint.Length);
        Vector3 spawnPosition = playerSpawnPoint[index].position;

        PhotonNetwork.Instantiate(playerPrefab.name, spawnPosition, Quaternion.identity);
    }

  
    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
}
