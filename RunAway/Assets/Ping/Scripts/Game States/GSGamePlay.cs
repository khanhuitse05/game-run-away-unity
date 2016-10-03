using System.Collections;
using UnityEngine;

public class GSGamePlay : GSTemplate
{
    public static int countPlaygame = 0;
    public GameObject guiHUD;

    bool _isPlaying = false;
    public bool isPlaying
    {
        get { return _isPlaying; }
    }
    static GSGamePlay _instance;
    public static GSGamePlay Instance { get { return _instance; } }
    protected override void Awake()
    {
        base.Awake();
        Utils.setActive(guiHUD, false);
        _instance = this;
    }

    protected override void init()
    {
        guiHUD.SetActive(true);
        startGame();
    }
    public override void onSuspend()
    {
        base.onSuspend();
        GameController.Instance.OnGameOver = null;
        guiHUD.SetActive(false);
    }

    public override void onResume()
    {
        base.onResume();
        GameController.Instance.OnGameOver = OnGameOver;
        guiHUD.SetActive(true);
    }
    protected override void onBackKey()
    {
    }
    void OnGameOver()
    {
        if (GameController.Instance.Score > GamePreferences.profile.HighScore)
        {
            GamePreferences.profile.updateHighScore(GameController.Instance.Score);
            GamePreferences.submitScore(GamePreferences.profile.HighScore);
        }
        
        _isPlaying = false;
        StartCoroutine("toResultState");
    }
    public IEnumerator toResultState()
    {
        yield return new WaitForSeconds(1f);
        GameStatesManager.Instance.StateMachine.SwitchState(GSResult.Instance);
    }
    void startGame()
    {
        _isPlaying = true;
        countPlaygame++;
        GameController.Instance.startGame();
    }
}
