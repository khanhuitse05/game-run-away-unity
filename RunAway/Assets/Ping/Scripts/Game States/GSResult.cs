using UnityEngine;
using UnityEngine.UI;

public class GSResult : GSTemplate
{
    public Text lbCurrentScore;
    public Text lbBestScore;
    public Text lbStar;
    bool isFirst;
    public GameObject ground;
    static GSResult _instance;
    public static GSResult Instance { get { return _instance; } }
    protected override void Awake()
    {
        base.Awake();
        _instance = this;
        isFirst = true;
    }
    protected override void init()
    {
        if (GSGamePlay.countPlaygame == 7 && GamePreferences.profile.Rate < 2)
        {
            GamePreferences.profile.Rate++;
            GamePreferences.saveProfile();
            PopupManager.Instance.InitYesNoPopUp("Love Block Dash?\nTell other how you fell.", onBtnRateClick, null, "RATE", "LATER");
        }

        ground.SetActive(isFirst);
        if (isFirst)
        {
            isFirst = false;
            showResult(0);
        }
        else
        {
            showResult(GameController.Instance.Score);
        }
    }

    void showResult(int _score)
    {
        lbBestScore.text = "" + GamePreferences.profile.HighScore.ToString() + " M";
        lbCurrentScore.text = _score.ToString() + " M";
        if (lbStar != null)
        {
            lbStar.text = GamePreferences.profile.Star.ToString();
        }
    }
    protected override void onBackKey()
    {
    }

    public void onBtnPlayClick()
    {
        GameStatesManager.Instance.stateMachine.SwitchState(GSGamePlay.Instance);
    }

    public void onBtnLikeClick()
    {
    }
    public void onBtnHowToPlay()
    {
    }
    public void onBtnRateClick()
    {
    }
    public void onBtnBoardClick()
    {
    }
    public void onBtnShopClick()
    {
    }

}