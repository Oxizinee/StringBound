using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController1 : MonoBehaviour
{
    // Start is called before the first frame update
    public float MovementSpeed = 5;
    public float JumpForce = 7;
    public bool _isGrounded;
    public Transform RopeHolder;


    public GameObject Character2;

    private bool _spacePressed;
    private Vector2 _input;
    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxis("HorizontalOne"), Input.GetAxis("VerticalOne"));
        _spacePressed = Input.GetKey(KeyCode.Space);

      //  RopeHolder.transform.position = transform.position;
    }
    private void FixedUpdate()
    {
        Move();
        //if (transform.position.magnitude + Character2.transform.position.magnitude > 10)
        //{
        //    _rb.AddRelativeForce(new Vector3(-transform.position.x, transform.position.y, -transform.position.z));
        //}
    }

    private void LateUpdate()
    {
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
