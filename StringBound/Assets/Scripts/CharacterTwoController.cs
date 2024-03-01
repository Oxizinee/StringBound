using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class CharacterTwoController : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 _input;
    public float MovementSpeed = 5;
    public GameObject JointSphere;
    public float extendSpeed = 1;
    private Rigidbody _rb;
    
    public bool IsBeingHeld;

    private float _buttonValue;
    private ConfigurableJoint _joint;
    private SoftJointLimit _jointLimit;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _joint = JointSphere.GetComponent<ConfigurableJoint>();
        _jointLimit = _joint.linearLimit;
    }

    private void OnStringHold(InputValue value)
    {
        _buttonValue = value.Get<float>();
    }
     private void OnMove(InputValue value)
    {
        _input = value.Get<Vector2>();
    }


    private void Update()
    {
        //HandleString();
    }

    private void HandleString()
    {
        if (_buttonValue > 0)
        {
            _jointLimit.limit = Mathf.Clamp(_jointLimit.limit + extendSpeed, 2, 6);
        }
        else if (_buttonValue <= 0)
        {
            _jointLimit.limit = Mathf.Clamp(_jointLimit.limit - extendSpeed, 2, 6);
        }

        _joint.linearLimit = _jointLimit;
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
        if (IsBeingHeld) return;


        _rb.velocity = new Vector3(Vector3.right.x * _input.x * MovementSpeed, _rb.velocity.y, Vector3.forward.z * _input.y * MovementSpeed);

        if (!isGrounded())
        {
            _rb.AddForce(-Vector3.up * 9.81f);
        }
    }

    public void AimMove(GameObject aim, float speed)
    {
        if(!IsBeingHeld) return;

        aim.SetActive(true);
        aim.transform.parent = null;
        aim.transform.Translate(new Vector3(Vector3.right.x * _input.x * speed * Time.deltaTime, 0, 
            Vector3.forward.z * _input.y * speed * Time.deltaTime));
    }
   
}
