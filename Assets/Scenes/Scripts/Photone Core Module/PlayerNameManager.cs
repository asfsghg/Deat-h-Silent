using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerNameManager : MonoBehaviourPunCallbacks
{
   [SerializeField] private TMP_InputField playerNameInputField;
   public override void OnConnectedToMaster()
   {
      LoadNickName();
   }

   private void LoadNickName()
   {
      string nickName = PlayerPrefs.GetString("NickName");
      
      if (string.IsNullOrEmpty(nickName))
      {
         int random = Random.Range(1, 1000);
         nickName = "Player " + random;
      }
      
      PhotonNetwork.NickName = nickName;
      playerNameInputField.text = nickName;
   }

   public void ChangeNickName()
   {
      PlayerPrefs.SetString("NickName", playerNameInputField.text);
      LoadNickName();
   }
}
