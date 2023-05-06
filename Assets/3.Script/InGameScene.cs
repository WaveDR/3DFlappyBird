using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScene : MonoBehaviour
{
    [SerializeField]
    private Text gameScoreText;

    private void Awake()
    {
        // ĳ���� Ʈ������ ����
        //RabbitController.Instance.transform.rotation = Quaternion.identity;

        // 3�� ���°�

        // ��������; ���� �����յ� ���⼭ ����
        // Instantiate(gameOverCanvas);
        // ()

        GameManager.Instance.OnChangeScore = null;
        GameManager.Instance.OnChangeScore += (() => gameScoreText.text = GameManager.Instance.Score.ToString());
    }



    public void ReStart()
    {
        GameManager.Instance.Scene.LoadScene(EScene.Lobby);
    }
}
