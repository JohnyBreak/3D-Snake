using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSLock : MonoBehaviour
{
    [SerializeField] private int _targetFps = 60; 

    private void Awake()
    {
        Application.targetFrameRate = _targetFps;
    }

    void Update()
    {
        if(Application.targetFrameRate != _targetFps) 
            Application.targetFrameRate = _targetFps;
    }
}
