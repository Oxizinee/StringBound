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
    public bool _isGrounded;

    public GameObject Sphere, SphereTwo, SphereThree;
    public GameObject Character2;

    public bool isGrabed;
    public float ThrowValue;
    public int ThrowStrength = 2500;

    private Vector2 _input;
    private Rigidbody _rb;
    private LineRenderer _lineRenderer;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _lineRenderer = GetComponentInChildren<LineRenderer>();
    }

    private void OnGrab()
    {
        isGrabed = !isGrabed;
    }
    private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }
    private void OnThrow(InputValue value)
    {
        ThrowValue = value.Get<float>();
    }

    private void GrabbingBehaviour()
    {
        if (isGrabed)
        {
            Character2.GetComponent<CharacterTwoController>().IsBeingHeld = true;
            Character2.GetComponent<Rigidbody>().isKinematic = true;
            if (ThrowValue > 0)
            {
                Character2.GetComponent<Rigidbody>().isKinematic = false;
                Character2.GetComponent<Rigidbody>().AddForce(Vector3.up * ThrowStrength * Time.deltaTime, ForceMode.VelocityChange);
                isGrabed = false;
            }
        }
        else
        {
            Character2.GetComponent<Rigidbody>().isKinematic = false;
            Character2.GetComponent<CharacterTwoController>().IsBeingHeld = false;
            Character2.transform.parent = null;
        }
    }
    // Update is called once per frame
    void Update()
    {
        GrabbingBehaviour();
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

        if (!isGrounded())
        {
            _rb.AddForce(-Vector3.up * 9.81f);
        }
    }

   
}
