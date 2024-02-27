using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEditor;

public class CameraControl : MonoBehaviour
{
    public CinemachineVirtualCamera VirtualCamera;
    public GameObject CharacterOne, CharacterTwo;
    public float MaxTransform, MinTransform;
    public int distance = 70;
    public int Speed = 7;

    private Vector3 _startPos;
    // Start is called before the first frame update
    void Start()
    {
        _startPos = VirtualCamera.transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
       Vector3 CharacterOneScreenPos = Camera.main.WorldToScreenPoint(CharacterOne.transform.position);
        Vector3 CharacterTwoScreenPos = Camera.main.WorldToScreenPoint(CharacterTwo.transform.position);

        if (CharacterOneScreenPos.x > Screen.width - distance || CharacterTwoScreenPos.x > Screen.width - distance)
        {
            VirtualCamera.transform.position += Vector3.right * Time.deltaTime * Speed;
        }
        else if(CharacterOneScreenPos.x < 0 + distance || CharacterTwoScreenPos.x < 0 + distance)
        {
            VirtualCamera.transform.position -= Vector3.right * Time.deltaTime * Speed;
        }

        else
        {
            VirtualCamera.transform.position = Vector3.Lerp(VirtualCamera.transform.position, _startPos, Time.deltaTime * 0.08F);
        }

    }
}
