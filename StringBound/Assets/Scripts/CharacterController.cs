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

        Move();
    }

    private void LateUpdate()
    {
        DrawRope();
    }
    private bool isGrounded()
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z), -Vector3.up, Color.red);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y/2), transform.position.z),-Vector3.up, 0.5f))
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
      
            if (_input.x != 0)
            {
                transform.position += Vector3.right * _input.x * Time.deltaTime * MovementSpeed;
            }
            if (_input.y != 0)
            {
                transform.position += Vector3.forward * _input.y * Time.deltaTime * MovementSpeed;
            }


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            _rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
            //transform.position += Vector3.up * Time.deltaTime * JumpForce;
        }
        else if(!isGrounded())
        {
            _rb.AddForce(-Vector3.up * 9.81f);
        }

    }
}
