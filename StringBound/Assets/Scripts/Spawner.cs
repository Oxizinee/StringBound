using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool[] check;
    public GameObject Box;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (check.All(x => x))
        {
            Instantiate(Box, transform.position, Quaternion.identity);
            Destroy(this);
        }
    }
}
