using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 5;
    public float JumpForce = 7;
    public bool _isGrounded;

    public GameObject Sphere, SphereTwo, SphereThree;
    public GameObject Character2;

    private bool _jumpPressed;
    private Vector2 _input;
    private Rigidbody _rb;
    private LineRenderer _lineRenderer;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _lineRenderer = GetComponentInChildren<LineRenderer>();
    }
    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }

    private void OnJump()
    {
            _jumpPressed = true;
    }

    // Update is called once per frame
    void Update()
    {
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
        _lineRenderer.positionCount = 5;
        _lineRenderer.SetPosition(0, transform.position);
        _lineRenderer.SetPosition(1, Sphere.transform.position);
        _lineRenderer.SetPosition(2, SphereTwo.transform.position);
        _lineRenderer.SetPosition(3, SphereThree.transform.position);
        _lineRenderer.SetPosition(4, Character2.transform.position);
    }

    private void Move()
    {
        _rb.velocity = new Vector3(Vector3.right.x * _input.x * MovementSpeed, _rb.velocity.y, Vector3.forward.z * _input.y * MovementSpeed);

        if (_jumpPressed && isGrounded())
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
        else if(!isGrounded())
        {
            _jumpPressed = false;
            _rb.AddForce(-Vector3.up * 9.81f);
        }

    }
}
