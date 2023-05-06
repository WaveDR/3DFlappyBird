using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene : BaseScene
{
    protected override void Init()
    {
        base.Init();

        // BGM ���
        GameManager.Instance.Sound.PlayBgm(EBGM.Background);
    }
}

