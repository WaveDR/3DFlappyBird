using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScene : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverCanvas;

    private void Awake()
    {
        // ĳ���� Ʈ������ ����
        //RabbitController.Instance.transform.rotation = Quaternion.identity;

        // 3�� ���°�

        // ��������; ���� �����յ� ���⼭ ����
        // Instantiate(gameOverCanvas);
        // 
    }


    public void ReStart()
    {
        GameManager.Instance.Scene.LoadScene(EScene.Lobby);
    }
}
