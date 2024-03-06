using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Door : MonoBehaviour
{
    // Start is called before the first frame update
    public bool[] check;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (check.All(x => x))
        {
            Destroy(gameObject);
        }
    }
}
