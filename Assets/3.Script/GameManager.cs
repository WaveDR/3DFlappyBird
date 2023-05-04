using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���߿� �̱��� ��ӹ���
public class GameManager : Singleton<GameManager>
{
    private FileManager _file = new FileManager();
    private SoundManager _sound = new SoundManager();

    public FileManager File => _file;
    public SoundManager Sound => _sound;

    private void Awake()
    {
        Debug.Log("�ҷ��ɴϴ�.");
        File.LoadGame();
    }

    private void OnApplicationQuit()
    {
        Debug.Log("�����մϴ�.");
        File.SaveGame();
    }
}
