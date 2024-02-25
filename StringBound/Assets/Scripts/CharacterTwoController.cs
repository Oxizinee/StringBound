using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxis("HorizontalTwo"), Input.GetAxis("VerticalTwo"));
    }

    private void FixedUpdate()
    {
        Move();

    }
    private void Move()
    {
        _rb.velocity = new Vector3(Vector3.right.x * _input.x * MovementSpeed, _rb.velocity.y, Vector3.forward.z * _input.y * MovementSpeed);
    }
}
