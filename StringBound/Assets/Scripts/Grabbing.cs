using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour
{
    public GameObject Character2;
    public Transform ShoulderPos;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Character2 && GetComponentInParent<CharacterController>().isHolding
            && other.gameObject.GetComponent<CharacterTwoController>().isStone == false)
        {
            Character2.transform.position = ShoulderPos.transform.position;
            Character2.transform.parent = transform.parent;
            Character2.GetComponent<CharacterTwoController>().IsBeingHeld = true;
        }

    }
}
