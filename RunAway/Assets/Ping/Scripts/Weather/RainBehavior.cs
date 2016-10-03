using UnityEngine;
using System.Collections;

public class RainBehavior : MonoBehaviour {
    const int MaxSize = 500;
    const int MaxTimeSun = 120;
    const int MaxTimeRain = 60;

    int total;
    float current;
    int size;
    bool isRain;
    public ParticleSystem ps;
    //GameObject rain;

    void Start()
    {
        isRain = Utils.Random(0, 1) == 0;
        initRain();
    }
    void initRain () {
        Utils.Log("Init Rain");
        isRain = !isRain; 
        current = 0;
        total = Utils.Random(20, isRain ? MaxTimeRain : MaxTimeSun);
        size = Utils.Random(50, MaxSize);
        //
        var rate = new ParticleSystem.MinMaxCurve();
        rate.constantMax = size;
        var em = ps.emission;
        em.rate = rate;
        //
        Utils.particleStartStop(ps, isRain);
    }
	
	// Update is called once per frame
	void Update () {
        current += Time.deltaTime;
        if (current > total)
        {
            initRain();
        }
	}
}
