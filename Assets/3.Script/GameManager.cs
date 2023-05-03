using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���߿� �̱��� ��ӹ���
public class GameManager : MonoBehaviour
{
    private FileManager _file = new FileManager();

    public FileManager File => _file;

    private void Awake()
    {
        Debug.Log("�ҷ��ɴϴ�.");
        File.LoadGame();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            File.saveData.scoreData.Add(new ScoreData("������", 30));
            Debug.Log(File.saveData.scoreData.Count + " ����� !!");
        }
    }

    private void OnApplicationQuit()
    {
        Debug.Log("�����մϴ�.");
        File.SaveGame();
    }
}
