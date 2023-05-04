using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RabbitController : Singleton<RabbitController>
{
    [SerializeField] float jumpForce;
    Rigidbody rigid;
    Animator ani;
    Vector3 defaultScale;
    public SkinnedMeshRenderer rend;
    public Material[] mat;
    bool isDead;
    bool isBig;

    private void Awake()
    {
        defaultScale = gameObject.transform.localScale;
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
        TryGetComponent(out rigid);
        TryGetComponent(out ani);
        
    }

    private void FixedUpdate()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }

        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                Jump();
            }
        }

    }

    void Jump()
    {
        if (!EventSystem.current.IsPointerOverGameObject()&&!isDead)
        {
            rigid.velocity = Vector3.zero;
            rigid.AddForce(Vector3.up*jumpForce);
            ani.SetTrigger("Jump");
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Pipe")&&!isDead&&!isBig)
        {
            //�װ� ���� ���ٰ� ȭ�� ���߰� ���ӿ��� ������ ���� ������,,,,,,,,,,,,,,,
            isDead = true;
            ani.SetTrigger("Die");
        }

        if (collision.transform.CompareTag("Pipe") && isBig)
        {
            //������ ������ ������ �ѽñ�
            Destroy(collision.collider.gameObject);

        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Item")&&!isDead)
        {
            isBig = true;
            Destroy(other.gameObject);
            StartCoroutine(sizeUpItemCo());
        }
    }

    IEnumerator sizeUpItemCo()
    {
        //Ŀ���� ������ �ѽð� �����ð� ���Ŀ� ���ƿ���
        int count = 0;
        while (count < 3)
        {
            transform.localScale *= 1.3f;
            yield return new WaitForSeconds(0.065f);
            count++;
        }
        ani.SetBool("Dance", true);
        yield return new WaitForSeconds(5f);

        while(transform.localScale.x>=defaultScale.x)
        {
            transform.localScale -= Vector3.one* 0.2f;
            yield return new WaitForSeconds(0.065f);
        }
        transform.localScale = defaultScale;
        ani.SetBool("Dance", false);
        isBig = false;
    }



}
