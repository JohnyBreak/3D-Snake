using UnityEngine;

[RequireComponent(typeof(SnakeHead))]
public class SnakeHeadJoystickMovement : MonoBehaviour
{
    [SerializeField] private DynamicJoystick _dynamicJoystick;
    [Space(10)]

    [SerializeField] private float _moveSpeed = 2;
    [SerializeField] private float _steerSpeed = 9;
    [SerializeField] private float _rotateSpeed = 10;

    private Transform _cameraT;
    private Transform _apple;
    private LayerMask _groundMask;

    private void Awake()
    {
        _cameraT = Camera.main.transform;

        _groundMask = GetComponent<SnakeHead>().GroundMask;
        _apple = GetComponent<SnakeHead>().Apple;
    }

    private void Update()
    {
        Vector3 directionFromAppleCenterToHead = transform.position - _apple.transform.position;
        directionFromAppleCenterToHead.Normalize();

        Vector3 cameraPlane = (_cameraT.right * _dynamicJoystick.Direction.x + _cameraT.up * _dynamicJoystick.Direction.y);
        cameraPlane.Normalize();

        RaycastHit hit;

        Physics.Raycast(transform.position, -transform.up, out hit, 3f, _groundMask);

        Quaternion RotToGround = Quaternion.FromToRotation(transform.up, directionFromAppleCenterToHead);
        transform.rotation = Quaternion.Lerp(transform.rotation, RotToGround * transform.rotation, _rotateSpeed * Time.deltaTime);

        transform.position = hit.point + transform.up * 0.5f;
        
        if (_dynamicJoystick.Direction.magnitude >= 0.1)
        {
            Quaternion lookRotation = Quaternion.LookRotation(cameraPlane, directionFromAppleCenterToHead);
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, _steerSpeed * Time.deltaTime);
        }
        transform.position += transform.forward * _moveSpeed * Time.deltaTime;
    }
}
