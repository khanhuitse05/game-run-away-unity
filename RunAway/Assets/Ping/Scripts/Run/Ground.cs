using UnityEngine;
using System;
using System.Collections;

public class Ground : MonoBehaviour {
    public const int WIDTH_MIN = 64;
    public const int HEIGHT_MIN = 95;
    public const int HEIGHT_TERRACE = 20;

    public int width;
    public int height;
    public RectTransform rectTranform;
    public RectTransform terrace;
    public BoxCollider2D _collider;
    public Action<Ground> deActive;

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public void Activate()
    {
        gameObject.SetActive(true);
    }
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
    public void init(int ww, int hh, int xx)
    {
        width = ww;
        height = hh;
        int _wFix = ((int)ww / WIDTH_MIN) * WIDTH_MIN;
        int _hFix = ((int)hh / HEIGHT_MIN + 1) * HEIGHT_MIN;

        rectTranform.sizeDelta = new Vector2(_wFix, _hFix);
        int _posY = HEIGHT_TERRACE + hh - _hFix;
        rectTranform.localPosition = new Vector2(xx, _posY);

        terrace.sizeDelta = new Vector2(ww, HEIGHT_TERRACE);
        terrace.localPosition = new Vector2((float)_wFix / 2, _hFix);

        _collider.offset = new Vector2((float)_wFix / 2, (float)(_hFix + HEIGHT_TERRACE) / 2);
        _collider.size = new Vector2(ww, _hFix + HEIGHT_TERRACE);
    }
    Vector3 _vel;
    void Update()
    {
        if (GameController.Instance.isGamePlay)
        {
            _vel = new Vector3(GameController.Instance.speed, 0, 0);
            transform.localPosition -= _vel * Time.deltaTime;
            if (transform.localPosition.x < 0 - (650 + width))
            {
                deActive(this);
            }
        }
    }
}
