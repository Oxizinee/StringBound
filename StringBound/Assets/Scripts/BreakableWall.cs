using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public GameObject wall;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player" && collision.gameObject.GetComponent<CharacterTwoController>())
        {
            if (collision.gameObject.GetComponent<CharacterTwoController>().isStone && !collision.gameObject.GetComponent<CharacterTwoController>().isGrounded())
            {
                Destroy(wall);
                Destroy(this);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
