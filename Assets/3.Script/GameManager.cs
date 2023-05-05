using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ���߿� �̱��� ��ӹ���
public class GameManager : Singleton<GameManager>
{
    private FileManager _file = new FileManager();
    private SoundManager _sound = new SoundManager();
    private SceneManagerEx _scene = new SceneManagerEx();

    public FileManager File => _file;
    public SoundManager Sound => _sound;
    public SceneManagerEx Scene => _scene;


    // ���߿� Init���� �ؾ���
    private void Awake()
    {
        Debug.Log("�ҷ��ɴϴ�.");
        File.LoadGame();

        Scene.Init();
        Sound.Init();

        //RabbitController.Instance.onDie += GameOver;
    }

    private void GameOver()
    {
        GameObject gameOverCanvas = GameObject.Find("GameOverCanvas");
        gameOverCanvas.transform.GetChild(0).gameObject.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("�����մϴ�.");
        File.SaveGame();
    }
}
