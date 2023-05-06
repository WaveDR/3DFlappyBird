using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScene : MonoBehaviour
{
    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        GameManager.Instance.Init();
    }
}
