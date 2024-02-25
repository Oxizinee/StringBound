using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private Transform _positionA;
    [SerializeField]private Transform _positionB;

    public float Speed = 5;

    private Vector3 _targetPos;
    void Start()
    {
        _targetPos = _positionB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, _positionA.position) < 0.1f)
        {
            _targetPos = _positionB.position;
        }
        if (Vector3.Distance(transform.position, _positionB.position) < 0.1f)
        {
            _targetPos = _positionA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _targetPos, Speed * Time.deltaTime);
    }
}
