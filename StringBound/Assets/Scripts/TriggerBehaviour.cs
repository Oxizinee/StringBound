using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public string ObjectTag;
    public int checkNumber;
    private GameObject _doors;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ObjectTag)
        {
            _doors = GameObject.FindGameObjectWithTag("Door");
            _doors.GetComponent<Door>().check[checkNumber] = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _doors = null;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
