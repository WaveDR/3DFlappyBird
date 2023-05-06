using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[System.Serializable]
public class ScoreData : IComparable
{
    public string playerName;
    public int playerScore;

    public ScoreData(string playerName, int playerScore)
    {
        this.playerName = playerName;
        this.playerScore = playerScore;
    }

    public int CompareTo(object obj)
    {
        return ((ScoreData)obj).playerScore.CompareTo(playerScore);
    }

    public static bool operator >(ScoreData op1, ScoreData op2)
    {
        return (op1.playerScore > op2.playerScore);
    }

    public static bool operator <(ScoreData op1, ScoreData op2)
    {
        return !(op1 > op2);
    }
}


[System.Serializable]
public class GameData
{
    public int maxScore = 0;
    public List<ScoreData> scoreData = new List<ScoreData>();

    public GameData() 
    {
        scoreData = new List<ScoreData>();
    }


    /// <summary>
    /// add�� �� ũ�� ������ ������ �����ش�.
    /// </summary>
    /// <param name="scoreData">list�� ���� scoreData</param>
    public void AddScoreData(ScoreData scoreData)
    {
        int index = 0;

        for(int i = 0; i < this.scoreData.Count; i++)
        {
            // ���ο� ���� �� Ŭ ��� �� �ڸ��� ��ü�Ѵ�.
            if(this.scoreData[i] < scoreData)
            {
                index = i;
                break;
            }
        }

        this.scoreData.Insert(index, scoreData);
    }
}
