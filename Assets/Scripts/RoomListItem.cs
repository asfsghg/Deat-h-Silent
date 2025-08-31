
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class RoomListItem : MonoBehaviour
{
    [SerializeField] private TMP_Text roomName;
    private RoomInfo _roomInfo;
    private Button _Button;

    private void Start()
    {
        _Button = GetComponent<Button>();
        _Button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        LobbyManager.Instance.JoinRoom(_roomInfo);
    }

    public void SetRoomInfo(RoomInfo roomInfo)
    {
        _roomInfo = roomInfo;
        roomName.name = roomInfo.Name;
    }
}
