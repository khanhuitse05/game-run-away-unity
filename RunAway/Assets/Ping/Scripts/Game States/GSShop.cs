using UnityEngine;
using UnityEngine.UI;

public class GSShop : GSTemplate
{
    public GameObject pfItem;
    public Text txtStar;
    static GSShop _instance;
    public static GSShop Instance { get { return _instance; } }
    protected override void Awake()
    {
        base.Awake();
        _instance = this;
    }

    protected override void init()
    {
        txtStar.text = GamePreferences.profile.Star.ToString();
        LoadShop();
    }
    void LoadShop()
    {
    }
    protected override void onBackKey()
    {
        onBtnOkClick();
    }

    public void onBtnOkClick()
    {
        GamePreferences.saveProfile();
        GameStatesManager.Instance.stateMachine.SwitchState(GSGamePlay.Instance);
    }

}