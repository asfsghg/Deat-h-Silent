using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using Photon.Realtime;
public class PlayerListItem : MonoBehaviourPunCallbacks
{
   [SerializeField] private TMP_Text playernameText;
   private Player _player;

   public void SetPlayer(Player player)
   {
      
      _player = player;
      playernameText.text = player.NickName;
   }

   public override void OnPlayerLeftRoom(Player otherPlayer)
   {
      if (Equals(_player, otherPlayer))
      {
         Destroy(gameObject);
      }
   }

   public override void OnLeftRoom()
   {
      Destroy(gameObject);
   }
}
