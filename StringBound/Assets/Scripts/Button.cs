using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject switchObject;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            switchObject.SetActive(true);
        }
    }

    private void Start()
    {
        switchObject.SetActive(false);
    }
}
