using UnityEngine;
using Photon.Pun;
using TMPro;

public class Network : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text playerCountersText;

    public override void OnJoinedLobby()
    {
        int players = PhotonNetwork.CountOfPlayers;
        playerCountersText.SetText($"Players in Online: {players}");
    }
}