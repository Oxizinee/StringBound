using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterTwoController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 _input;
    public float MovementSpeed = 5;

    private Rigidbody _rb;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

     private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }


    private void FixedUpdate()
    {
        Move();

    }
    private bool isGrounded()
    {
        Debug.DrawRay(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z), -Vector3.up, Color.red);
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y - (transform.localScale.y / 2), transform.position.z), -Vector3.up, 0.8f))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private void Move()
    {
        _rb.velocity = new Vector3(Vector3.right.x * _input.x * MovementSpeed, _rb.velocity.y, Vector3.forward.z * _input.y * MovementSpeed);

        if (!isGrounded())
        {
            _rb.AddForce(-Vector3.up * 15);
        }
    }
}
