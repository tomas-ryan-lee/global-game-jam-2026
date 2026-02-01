using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField] private GameObject _player;
    [SerializeField] private float _speed;
    private CharacterController _characterController;

    [Header("Camera Settings")]
    [SerializeField] private Camera _playerCamera;
    [SerializeField] private float _distance = 5f;
    [SerializeField] private float _sensitivity = 3f;
    [SerializeField] private float _minY = -30f;
    [SerializeField] private float _maxY = 60f;

    float rotationX, rotationY;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        _characterController = _player.GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void LateUpdate()
    {
        MoveCamera();
    }

    private void Move()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _characterController.Move(move * Time.deltaTime * _speed);
    }

    private void MoveCamera()
    {
        if (GameManager.Instance._state == GameState.inGame || GameManager.Instance._state == GameState.resume)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            rotationX += Input.GetAxis("Mouse X") * _sensitivity;
            rotationY -= Input.GetAxis("Mouse Y") * _sensitivity;
            rotationY = Mathf.Clamp(rotationY, _minY, _maxY);

            Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);

            Vector3 targetPosition = _player.transform.position;
            Vector3 offset = rotation * new Vector3(0, 0, -_distance);

            _playerCamera.transform.position = targetPosition + offset;
            _playerCamera.transform.LookAt(targetPosition + Vector3.up * 1.5f);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
