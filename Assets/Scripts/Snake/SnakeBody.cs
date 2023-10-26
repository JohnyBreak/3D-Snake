using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeHead))]
public class SnakeBody : MonoBehaviour
{
    [SerializeField] private GameObject _bodyPrefab;
    [SerializeField] float _zOffset;
    [SerializeField] private float _bodySpeed = 3;
    
    private List<GameObject> _bodyParts = new List<GameObject>();
    private LayerMask _groundMask;
    private Transform _apple;

    private void Awake()
    {
        _groundMask = GetComponent<SnakeHead>().GroundMask;
        _apple = GetComponent<SnakeHead>().Apple;
    }

    void Start()
    {
        _bodyParts.Add(this.gameObject); // head added to list
    }

    void Update()
    {
        for (int i = 1; i < _bodyParts.Count; i++)
        {

            Vector3 targetPos = _bodyParts[i - 1].transform.position + _bodyParts[i - 1].transform.forward * _zOffset;
            Vector3 directionFromTargetPosToAppleCenter = _apple.transform.position - targetPos;

            RaycastHit hit;
            Physics.Raycast(targetPos, directionFromTargetPosToAppleCenter.normalized, out hit, 3f, _groundMask);

            targetPos = hit.point + -directionFromTargetPosToAppleCenter.normalized * 0.5f;

            Vector3 moveDir = targetPos - _bodyParts[i].transform.position;

            _bodyParts[i].transform.position += moveDir * _bodySpeed * Time.deltaTime;
            _bodyParts[i].transform.LookAt(targetPos);

        }

        //if (Input.GetKeyDown(KeyCode.Space))// for test
        //{
        //    GrowSnake();
        //}
    }

    public void GrowSnake() 
    {
        GameObject bodyPart = Instantiate(_bodyPrefab);

        bodyPart.transform.localRotation = _bodyParts[_bodyParts.Count - 1].transform.localRotation;

        bodyPart.transform.position = 
            _bodyParts[_bodyParts.Count - 1].transform.position
            + _bodyParts[_bodyParts.Count - 1].transform.forward * (-0.2f);

        _bodyParts.Add(bodyPart);
    }
}
