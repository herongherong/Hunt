using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//도끼투척 시 캐릭터 앞쪽에서 생성, 카메라 방향으로 날아가며 땅에 박힘

public class AxeThrow : MonoBehaviour
{
    //던져서 닿은 오브젝트(땅,구조물 or 적)
    GameObject TargetObj;
    Vector3 offset;

    //땅에 박힐 오브젝트
    public GameObject obj;

    [SerializeField]
    //던지는 스피드
    public float throwSpeed = 30;

    bool isCollision;

    //던졌을 당시의 회전각 (던지고 화면회전해서 닿았을때 뒤늦게 받으면 안됨)
    Quaternion pRotation;



    // Start is called before the first frame update
    void Start()
    {
        isCollision = false;
        TargetObj = null;
        offset = new Vector3(0, 0, 0);


        //던졌을 당시 회전각 받아오기
        playerCamera playercamera = GameObject.Find("Player").GetComponent<playerCamera>();
        float xRotationTemp = playercamera.xRotation;
        float yRotationTemp = playercamera.yRotation;
        pRotation = Quaternion.Euler(xRotationTemp, yRotationTemp, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (isCollision)
        {
            transform.position = TargetObj.transform.position - offset;
        }
        else
        {

            transform.Translate(Vector3.forward * throwSpeed * Time.deltaTime);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //tag == enemy, 
        if (other.tag == "Enemy")
        {
            //부딛친 타겟위치 발 아래로 해야함. 터레인 까지 y좌표 내려줘야하는데 나중에 코드 바꾸자...
            offset = transform.position;
            isCollision = true;
            Destroy(gameObject);
            Instantiate(obj, offset, pRotation);
        }

        if (other.tag == "wall" || other.tag == "Ground")
        {
            //충돌지점에
            offset = transform.position;
            isCollision = true;
            Destroy(gameObject);

            
            Instantiate(obj, offset, pRotation);
        }




    }
}
