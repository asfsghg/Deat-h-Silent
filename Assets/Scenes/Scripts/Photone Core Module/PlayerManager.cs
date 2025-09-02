using UnityEngine;
using Photon.Pun;
using System.IO;
using UnityEngine.SceneManagement;

public class PlayerManager : MonoBehaviourPunCallbacks
{
    private GameObject _controller;
    private PhotonView _photonView;
    
    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
    }

    private void Start()
    {
        if (_photonView.IsMine)
        {
            CreatePlayer();
        }
        
        if (GameManager.Instance != null)
        {
            GameManager.Instance.LeaveButton.onClick.RemoveListener(OnLeaveButtonClick);
            GameManager.Instance.LeaveButton.onClick.AddListener(OnLeaveButtonClick);
        }
    }

    private void CreatePlayer()
    {
        Vector3 spawnPoint = SpawnManager.Instance.GetSpawnPoint().transform.position;
        
        _controller = PhotonNetwork.Instantiate(
            Path.Combine("Player"), 
            spawnPoint,  
            Quaternion.identity,
            0,
            new object[] {photonView.ViewID});
        
    }
    
    public void Die()
    {
        PhotonNetwork.Destroy(_controller);
    }
    
    public void OnLeaveButtonClick()
    {
        if (PhotonNetwork.InRoom)
            PhotonNetwork.LeaveRoom();
        else
            SceneManager.LoadScene(0);
    }
}
