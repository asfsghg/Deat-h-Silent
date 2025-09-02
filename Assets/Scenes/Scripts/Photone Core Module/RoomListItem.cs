using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RoomListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text roomName;
    private RoomInfo _roomInfo;
    [SerializeField] private Button _button;
    
    private void Awake()
    {
        _button.onClick.AddListener(OnClick);
    }
    
    private void OnClick()
    {
        if (_roomInfo == null)
        {
            Debug.LogError("RoomInfo is null! Can't join.");
            return;
        }
        LobbyManager.Instance.JoinRoom(_roomInfo);
    }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        roomName.SetText($"{_roomInfo.Name} ({_roomInfo.PlayerCount}/{_roomInfo.MaxPlayers})");
    }

    public void CheckRoom()
    {
        if (_roomInfo != null && _roomInfo.PlayerCount >= _roomInfo.MaxPlayers)
        {
            _button.interactable = false;
        }
        else
        {
            _button.interactable = true;
        }
    }
    
}
