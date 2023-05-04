using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RabbitController : Singleton<RabbitController>
{
    [SerializeField] float jumpForce;
    Rigidbody rigid;

    public Animator ani;
    public Vector3 defaultScale;
    Vector3 view;
    public SkinnedMeshRenderer rend;
    public Material[] mat;

    public bool isDead;
    public bool isBig;


    private void Awake()
    {
        isDead = false;
        isBig = false;
        defaultScale = gameObject.transform.localScale;
        rend = GetComponentInChildren<SkinnedMeshRenderer>();
        TryGetComponent(out rigid);
        TryGetComponent(out ani);
        
        
    }


    private void Update()
    {
      
        view = Camera.main.WorldToViewportPoint(transform.position);
        //ȭ�� ������ ������ ����?
        if(view.y>1||view.y<0&&!isBig)
        {
            Die();
        }

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

    void Die()
    {
        isDead = true;
        ani.SetTrigger("Die");
        Debug.Log("����");
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Pipe")&&!isDead&&!isBig)
        {
            //�װ� ���� ���ٰ� ȭ�� ���߰� ���ӿ��� ������ ���� ������,,,,,,,,,,,,,,,
            Die();
        }

        if (collision.transform.CompareTag("Pipe") && isBig)
        {
            //������ ������ ������ �ѽñ�
            collision.collider.gameObject.SetActive(false);

        }



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Item")&&!isDead)
        {
            IItem item = other.GetComponent<IItem>();
            if (item != null)
            {
                item.Use();
                Destroy(other.gameObject);
            }
        }
    }

    public void Carrot()
    {
        StartCoroutine(sizeUpItemCo());
    }

    public IEnumerator sizeUpItemCo()
    {
        //Ŀ���� ������ �ѽð� �����ð� ���Ŀ� ���ƿ���
        isBig = true;
        int count = 0;
        while (count < 7)
        {
            RabbitController.Instance.transform.localScale *= 1.3f;
            yield return new WaitForSeconds(0.065f);
            count++;
        }
        ani.SetBool("Dance", true);
        yield return new WaitForSeconds(5f);

        while (transform.localScale.x >= defaultScale.x)
        {
            transform.localScale -= Vector3.one * 0.3f;
            yield return new WaitForSeconds(0.065f);
        }
        transform.localScale = defaultScale;
        ani.SetBool("Dance", false);
        isBig = false;
    }




}
