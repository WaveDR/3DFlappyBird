using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Movement: MonoBehaviour
{
    [SerializeField] private float objectMoveSpeed;

    [Header("Instance Value")]

    [SerializeField] private int valueBoxCount;

    [Header("Vector Info")]

    [SerializeField] private Vector3 objectVectorEnd;
    [SerializeField] private Vector3 objectVectorStart;
    [SerializeField] private Transform objectPoolVector;


    [Header("Instance Info")]

    [SerializeField] private GameObject[] objectUpBoxArray;
    [SerializeField] private GameObject[] objectUpBoxPrefab;
    [SerializeField] private Transform[] objectUpBoxPosArray;

    [SerializeField] private GameObject[] objectDownBoxArray;
    [SerializeField] private GameObject[] objectDownBoxPrefab;
    [SerializeField] private Transform[] objectDownBoxPosArray;


    private int valueCountPlus;
    private int valueRandNum;
    private int valueBoxPrefab;


    /*
        1. �� ������ ��յ��� 3���� Instance�Ѵ�.
        2. Ȱ��ȭ �� ������ ��յ� �� �������� ȣ�� 
        3. Ȱ��ȭ�Ǹ� �������� �̵�

      */

    private void Awake()
    {
        //Box Array = ���� ���� x ���� �� ���� 
        objectUpBoxArray = new GameObject[valueBoxCount];
        objectDownBoxArray = new GameObject[valueBoxCount];

        //������ ���� ���� ��ŭ for������ ��ȯ
        for (int i = 0; i < objectUpBoxArray.Length; i++)
        {
            //Pool Vector�� �� ������ �����۵��� Instance
            objectUpBoxArray[i] = Instantiate(objectUpBoxPrefab[valueBoxPrefab], objectPoolVector.position, Quaternion.identity, objectPoolVector);
            objectDownBoxArray[i] = Instantiate(objectDownBoxPrefab[valueBoxPrefab], objectPoolVector.position, Quaternion.identity, objectPoolVector);

            objectUpBoxArray[i].SetActive(false);
            objectDownBoxArray[i].SetActive(false);
            //=====================================================  �� ������ ������ ���� ������ ī��Ʈ�� �й��Ͽ� ���� ��ȯ
            valueBoxPrefab++;

            if(valueBoxPrefab >= objectUpBoxPrefab.Length)
            {
                valueBoxPrefab = 0;
            }
        }
    }
    private void OnEnable()
    {
        for (int i = 0; i < objectUpBoxPosArray.Length; i++)
        {
            valueRandNum = Random.Range(0, objectUpBoxArray.Length);

            if (!objectUpBoxArray[valueRandNum].activeSelf)
            {
                objectUpBoxArray[valueRandNum].SetActive(true);
                objectUpBoxArray[valueRandNum].transform.position = objectUpBoxPosArray[i].position;
            }
            else
            {
                i--;
                continue;
            }
        }

        for (int i = 0; i < objectDownBoxPosArray.Length; i++)
        {
            valueRandNum = Random.Range(0, objectDownBoxArray.Length);

            if (!objectDownBoxArray[valueRandNum].activeSelf)
            {
                objectDownBoxArray[valueRandNum].SetActive(true);
                objectDownBoxArray[valueRandNum].transform.position = objectDownBoxPosArray[i].position;
            }

            else
            {
                i--;
                continue;
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * objectMoveSpeed * Time.deltaTime);

        if(transform.position.x <= objectVectorEnd.x)
        {
            transform.position = objectVectorStart;
        }
    }
}
