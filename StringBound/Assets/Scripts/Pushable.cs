using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody _rb;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.rigidbody.mass <= 1)
            {
                _rb.constraints = RigidbodyConstraints.FreezePosition;
            }
            else
            {
                _rb.constraints = RigidbodyConstraints.None;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        _rb.constraints = RigidbodyConstraints.None;
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

}
