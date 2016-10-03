using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GSTutorial : GSTemplate
{
    static GSTutorial _instance;
    public static GSTutorial Instance { get { return _instance; } }
    protected override void Awake()
    {
        base.Awake();
        _instance = this;
    }
    protected override void init()
    {
        Invoke("startTutorial", 1);
    }
    void startTutorial()
    {
    }
    void Update()
    {
    }
    protected override void onBackKey()
    {
        onBtnPlayClick();
    }

    public void onBtnPlayClick()
    {
        GamePreferences.profile.EnableTutorial = false;
        GamePreferences.saveProfile();
        GameStatesManager.Instance.stateMachine.SwitchState(GSGamePlay.Instance);
    }
}

