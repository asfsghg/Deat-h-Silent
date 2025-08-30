
using UnityEngine;
using Photon.Pun;
using TMPro;

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
            int random = UnityEngine.Random.Range(0, 456);
            nickName = nickName + random;
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
