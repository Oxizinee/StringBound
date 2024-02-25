using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float currentSpeed;
    public float MovementSpeed = 5;
    public float maxVelocity = 20;

    public GameObject Character2;

    private Vector2 _inputOne, _inputTwo;
    private Rigidbody _rb;
    private SpringJoint _springJoint;
    private LineRenderer _lineRenderer;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _lineRenderer = GetComponent<LineRenderer>();
        _springJoint = GetComponent<SpringJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        _inputOne = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
       // _springJoint.connectedAnchor = Character2.transform.position;

        Move();
    }

    private void LateUpdate()
    {
        DrawRope();
    }

    private void DrawRope()
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, Character2.transform.position);
    }

    private void Move()
    {

        if (_inputOne.x != 0)
        {
           transform.position += transform.right * _inputOne.x * Time.deltaTime * MovementSpeed;
        }
        if (_inputOne.y != 0)
        {
            transform.position += transform.forward * _inputOne.y * Time.deltaTime * MovementSpeed;
        }

    }
}
