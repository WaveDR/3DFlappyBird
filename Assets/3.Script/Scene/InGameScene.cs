using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameScene : BaseScene
{
    [SerializeField]
    private RabbitSpawner rabbitSpawner;
    [SerializeField]
    private BaseUI waitingUI;
    [SerializeField]
    private BaseUI gameOverUI;

    private RabbitController rabbit;


    public void ReStart()
    {
        GameManager.Instance.Scene.LoadScene(EScene.Lobby);
    }

    protected override void Init()
    {
        base.Init();


        // �÷��̾� ����
        rabbit = rabbitSpawner.RespawnRabbit();

        // �÷��̾� ���� �� gameOverUI Ȱ��ȭ ���ֱ�
        rabbit.onDie += (() => GameManager.Instance.UI.ShowUI(gameOverUI));

        // ī��Ʈ�ٿ� UI Show
        GameManager.Instance.UI.ShowUI(waitingUI);
    }
}