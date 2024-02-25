using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 5;
    public float JumpForce = 7;
    public bool _isGrounded;


    public GameObject Character2;

    private bool _spacePressed;
    private Vector2 _input;
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
        _input = new Vector2(Input.GetAxis("HorizontalOne"), Input.GetAxis("VerticalOne"));
        _spacePressed = Input.GetKey(KeyCode.Space);
    }
    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        DrawRope();
    }
    private bool isGrounded()
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z), -Vector3.up, Color.red);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y/2), transform.position.z),-Vector3.up, 0.8f))
            {
                _isGrounded = true;
                return true;
            }
        else
        {
            _isGrounded = false;
            return false;
        }
    }

    private void DrawRope()
    {
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, Character2.transform.position);
    }

    private void Move()
    {
        _rb.velocity = new Vector3(Vector3.right.x * _input.x * MovementSpeed, _rb.velocity.y, Vector3.forward.z * _input.y * MovementSpeed);

        if (_spacePressed && isGrounded())
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        else if(!isGrounded())
        {
            _rb.AddForce(-Vector3.up * 9.81f);
        }

    }
}
