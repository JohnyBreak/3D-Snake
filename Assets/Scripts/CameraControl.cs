using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _rotationTarget;
    [SerializeField] private Transform _followTarget;
    [SerializeField] private Vector3 _offset = new Vector3(0, 0, -10);

    private void Update()
    {
        Vector3 dir = _followTarget.position - _rotationTarget.position;
        dir = dir.normalized;
        _camera.transform.position = _rotationTarget.position + dir * -_offset.z;
        _camera.transform.LookAt(_followTarget, _camera.transform.up);
    }
}
