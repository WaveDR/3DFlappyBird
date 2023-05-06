using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private Text scorePointText;
    [SerializeField] private Text bestScorePointText;

    [SerializeField] private RankingUI rankingUI;

    /// <summary>
    /// ���� ������ GameOverUI Ȱ��ȭ
    /// Ȱ��ȭ�ϸ� �̸��� ������ �����ͼ� ���� �� UI ����
    /// </summary>
    private void OnEnable()
    {
        //Debug.Log(RabbitController.Instance.nickName);

        // ������ ��������
        string nickName = SelectRabbit.Instance.nickName;
        int score = GameManager.Instance.Score;
        ScoreData scoreData = new ScoreData(nickName, score);

        // score ���
        GameManager.Instance.File.RecordData(scoreData);
        rankingUI.InitData(scoreData);

        // UI ����
        scorePointText.text = score.ToString();

        // �ű�� ����
        if(GameManager.Instance.File.GameData.maxScore < score)
        {
            Debug.Log("�ű��!");
            GameManager.Instance.File.GameData.maxScore = score;
        }
        bestScorePointText.text = GameManager.Instance.File.GameData.maxScore.ToString();
    }
}
