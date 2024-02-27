using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharactersControlers : MonoBehaviour
{
    // Start is called before the first frame update
    public float PlayerOneMovementSpeed = 10;
    public float PlayerTwoMovementSpeed = 5;
    public float JumpForce = 7;
    public bool _isGrounded;
    public bool _playerOneActive = true;


    public GameObject Character2;

    private bool _jumpPressed;
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
    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    private void OnJump()
    {
            _jumpPressed = true;
    }

    private void OnChange()
    {
        _playerOneActive = !_playerOneActive;
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
        if (_playerOneActive)
        {
            _rb.velocity = new Vector3(Vector3.right.x * _input.x * PlayerOneMovementSpeed, _rb.velocity.y, Vector3.forward.z * _input.y * PlayerOneMovementSpeed);

            if (_jumpPressed && isGrounded())
            {
                _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            }
            else if (!isGrounded())
            {
                _jumpPressed = false;
                _rb.AddForce(-Vector3.up * 9.81f);
            }
        }

        else
        {
            Character2.GetComponent<Rigidbody>().velocity = new Vector3(Vector3.right.x * _input.x * PlayerTwoMovementSpeed, _rb.velocity.y, Vector3.forward.z * _input.y * PlayerTwoMovementSpeed);
        }
    }
}
