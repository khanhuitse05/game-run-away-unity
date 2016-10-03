using UnityEngine;
using System.Collections;

public class SunBehavior : MonoBehaviour {
    public int timeDay = 300;
    public int timeNight = 200;
    bool isDay;
    int totalTime;
    float currentTime;
    public Transform startPos;
    public Transform endPos;
    public GameObject sun;
    public GameObject moon;
    public GameObject dark;
    GameObject currentLight;

    void Start () {

        isDay = Utils.Random(0, 2) == 0;
        initSun();
    }
    bool isFist = true;
	void initSun()
    {
        isDay = !isDay;
        if (isFist)
        {
            isFist = false;
            currentTime = Utils.Random(0, timeNight);
        }
        else
        {
            currentTime = 0;
        }
        if (isDay)
        {
            currentLight = sun;
            Utils.setActive(dark, false);
            Utils.setActive(moon, false);
            Utils.setActive(sun, true);
        }
        else
        {
            currentLight = moon;
            Utils.setActive(dark, true);
            Utils.setActive(moon, true);
            Utils.setActive(sun, false);
        }
        totalTime = isDay ? timeDay : timeNight;
    }
    void updatePosition()
    {
        float _tl = currentTime / (float)totalTime;
        float _xx = startPos.position.x + (endPos.position.x - startPos.position.x) * _tl;
        float _yy = startPos.position.y + (endPos.position.y - startPos.position.y) * _tl;
        Vector3 _pos = new Vector3(_xx, _yy, startPos.position.z);
        currentLight.transform.position = _pos;
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > totalTime)
        {
            initSun();
        }
        updatePosition();
    }
}
