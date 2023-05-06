using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    [SerializeField] private BaseUI SelectRabbitUI;


    // �κ�� �̵� �� �� ��
    // �䳢 ���� UI ǥ��
    // �ش� ���� ��� ��
    protected override void Init()
    {
        base.Init();

        GameManager.Instance.UI.ShowUI(SelectRabbitUI);
    }
}
