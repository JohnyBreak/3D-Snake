using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeHead : MonoBehaviour
{

    [SerializeField] private Transform _apple;
    [SerializeField] private LayerMask _groundMask;
    public LayerMask GroundMask => _groundMask;
    public Transform Apple => _apple;
}
