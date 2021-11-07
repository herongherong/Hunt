using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        //카메라홀더가 카메라 포지션에 계속 붙에 해준다.
        transform.position = cameraPosition.position;
    }
}
