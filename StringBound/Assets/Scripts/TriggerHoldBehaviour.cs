using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TriggerHoldBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    public string ObjectTag;
    public Material HighlightMat;
    private Material _deafultMat;
    public int checkNumber;
    private GameObject _spawner;
    public MeshRenderer _meshRenderer;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == ObjectTag)
        {
            _meshRenderer.sharedMaterial = HighlightMat;
            if (GameObject.FindGameObjectWithTag("Spawner") != null)
            {
                _spawner = GameObject.FindGameObjectWithTag("Spawner");
                _spawner.GetComponent<Spawner>().check[checkNumber] = true;
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ObjectTag)
        {
            _meshRenderer.sharedMaterial = _deafultMat;
            if (GameObject.FindGameObjectWithTag("Spawner") != null)
            {
                _spawner.GetComponent<Spawner>().check[checkNumber] = false;
                _spawner = null;
            }
        }
    }

    private void Start()
    {
        _deafultMat = _meshRenderer.sharedMaterial; 
    }

}
