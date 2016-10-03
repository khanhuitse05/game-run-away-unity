using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ColorEffect : MonoBehaviour {

    const float brightness = 1f;
    const float saturation = 1f;
    public float hue = 0f;
    public float speed = 0.0002f;
    public Image _renderer;
    // Use this for initialization
    void Start()
    {
        if (_renderer == null)
        {
            _renderer = gameObject.GetComponent<Image>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        hue += speed;
        if (hue > 1)
        {
            hue -= 1;
        }
        _renderer.color = Color.HSVToRGB(hue, saturation, brightness);
    }
}
