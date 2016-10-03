using UnityEngine;
public class GSHome : GSTemplate
{
    bool isNewLaunch = true;

    static GSHome _instance;
    public static GSHome Instance { get { return _instance; } }
    protected override void Awake()
    {
        base.Awake();
        _instance = this;
    }
    
    protected override void init()
    {
        //if (GamePreferences.profile.EnableTutorial)
        //{
        //    GameStatesManager.Instance.stateMachine.SwitchState(GSTutorial.Instance);
        //}
        if (isNewLaunch)
        {
            isNewLaunch = false;
            GamePreferences.submitScore(GamePreferences.profile.HighScore);
        }
    }
    public void onBtnPlayClick()
    {
        GameStatesManager.Instance.stateMachine.SwitchState(GSGamePlay.Instance);
    }
    public void onBtnLikeClick()
    {
        Application.OpenURL("https://www.facebook.com/");
    }
    
    public void onBtnHowToPlay()
    {
        GameStatesManager.Instance.stateMachine.SwitchState(GSTutorial.Instance);
    }
    public void onBtnRateClick()
    {
    }
    public void onBtnLearderBoardClick()
    {
        PopupManager.Instance.InitMesage("not available");
    }
    public void onBtnCustomizeClick()
    {
        GameStatesManager.Instance.stateMachine.SwitchState(GSShop.Instance);
    }
}