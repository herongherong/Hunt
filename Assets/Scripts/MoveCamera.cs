using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    [SerializeField] Transform cameraPosition;

    // Update is called once per frame
    void Update()
    {
        //ī�޶�Ȧ���� ī�޶� �����ǿ� ��� �ٿ� ���ش�.
        transform.position = cameraPosition.position;
    }
}
