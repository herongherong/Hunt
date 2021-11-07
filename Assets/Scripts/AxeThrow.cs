using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//������ô �� ĳ���� ���ʿ��� ����, ī�޶� �������� ���ư��� ���� ����

public class AxeThrow : MonoBehaviour
{
    //������ ���� ������Ʈ(��,������ or ��)
    GameObject TargetObj;
    Vector3 offset;

    //���� ���� ������Ʈ
    public GameObject obj;

    [SerializeField]
    //������ ���ǵ�
    public float throwSpeed = 30;

    bool isCollision;

    //������ ����� ȸ���� (������ ȭ��ȸ���ؼ� ������� �ڴʰ� ������ �ȵ�)
    Quaternion pRotation;



    // Start is called before the first frame update
    void Start()
    {
        isCollision = false;
        TargetObj = null;
        offset = new Vector3(0, 0, 0);


        //������ ��� ȸ���� �޾ƿ���
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
            //�ε�ģ Ÿ����ġ �� �Ʒ��� �ؾ���. �ͷ��� ���� y��ǥ ��������ϴµ� ���߿� �ڵ� �ٲ���...
            offset = transform.position;
            isCollision = true;
            Destroy(gameObject);
            Instantiate(obj, offset, pRotation);
        }

        if (other.tag == "wall" || other.tag == "Ground")
        {
            //�浹������
            offset = transform.position;
            isCollision = true;
            Destroy(gameObject);

            
            Instantiate(obj, offset, pRotation);
        }




    }
}
