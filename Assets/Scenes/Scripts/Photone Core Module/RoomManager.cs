using System.IO;
using Photon.Pun;
using UnityEngine;

public partial class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;
    
    private void Awake()
    {
        Instance = this;

        if (PhotonNetwork.IsMasterClient)
        {
            TrySpawnLocalPlayerManager();
        }
    }
    
    public override void OnJoinedRoom()
    {
        TrySpawnLocalPlayerManager();
    }

    private void TrySpawnLocalPlayerManager()
    {
        PhotonNetwork.Instantiate(
                Path.Combine("PlayerManager"),
                Vector3.zero,
                Quaternion.identity);
    }
}