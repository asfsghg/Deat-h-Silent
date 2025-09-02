using UnityEngine;
using Photon.Pun;
using TMPro;

public class NetworkPlayersStatistics : MonoBehaviourPunCallbacks
{
    [SerializeField] private TMP_Text playersCountText;

    public override void OnJoinedLobby()
    {
        int players = PhotonNetwork.CountOfPlayers;
        playersCountText.SetText($"Players in Online: {players}");
    }
}
