using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour, IPunObservable
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Text _nameText;
    [SerializeField] private Camera playerCamera;

    private Rigidbody rb;
    private PhotonView _photonView;


    [SerializeField] private float _rotionSpeed;
    public float speed = 5f;
    public float jumpForce = 5f;
    public int Health = 100;
    private bool isJumping = false;

    private float _currentRotationY = 0f;

    private void Awake()
    {
        _photonView = GetComponent<PhotonView>();
        rb = GetComponent<Rigidbody>();

        if (_photonView.IsMine)
        {
            _hpBar.maxValue = Health;
            _hpBar.value = Health;
            _nameText.text = PhotonNetwork.NickName;
            _nameText.enabled = true;
            _nameText.enabled = false;
        }
        else
        {
            playerCamera.enabled = false;
        }
    }

    private void Update()
    {
        if (!_photonView.IsMine) return;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * moveVertical * speed;
        movement.y = rb.velocity.y;
        rb.velocity = movement;

        _currentRotationY += moveHorizontal * _rotionSpeed * Time.deltaTime;
        rb.rotation = Quaternion.Euler(0, _currentRotationY, 0);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        _hpBar.value = Health;

        if (Health <= 0)
        {
            if (_photonView.IsMine)
            {
                GameManager.Instance.LeaveRoom();
            }
        }
    }


    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(Health);
            stream.SendNext(_hpBar.value);
        }
        else
        {
            Health = (int)stream.ReceiveNext();
            _hpBar.value = (float)stream.ReceiveNext();
        }
    }
}
