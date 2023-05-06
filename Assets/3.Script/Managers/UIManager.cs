using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    private Stack<BaseUI> ui = new Stack<BaseUI>();

    public void Init()
    {
        ui = new Stack<BaseUI>();

        // �� �̵� �� ��� UI ����
        GameManager.Instance.Scene.onChangeScene += ClearUI;
    }

    // ��� UI�� �ݽ��ϴ�.
    public void ClearUI()
    {
        while(ui.Count > 0)
        {
            ExitUI();
        }
    }

    // �� UI�� ����� �ش� UI�� �����ݴϴ�.
    public void ShowUI(BaseUI newUI)
    {
        if(ui.Count != 0)
        {
            BaseUI prevUI = ui.Peek();
            prevUI.Exit();
        }
        ui.Push(newUI);
        newUI.Show();
    }

    // ���� ���� �ִ� UI�� �����ݴϴ�.
    public void ExitUI()
    {
        // ui�� ������ ����
        if(ui.Count != 0)
        {
            ui.Peek().Exit();
            ui.Pop();

            // ui�� pop�ص� ���� ���������� �� ui������
            if(ui.Count != 0)
            {
                ui.Peek().Show();
            }
        }
        else
        {
            Debug.Log("UI�� �����ϴ�.");
        }
    }
}
