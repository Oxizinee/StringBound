using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterTwoController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 _input;
    public float MovementSpeed = 5;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _input = new Vector2(Input.GetAxis("HorizontalTwo"), Input.GetAxis("VerticalTwo"));
        Move();
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
    }
}
