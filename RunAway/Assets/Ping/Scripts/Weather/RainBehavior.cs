using UnityEngine;
using System.Collections;

public class RainBehavior : MonoBehaviour {
    const int MaxSizeRain = 500;
    const int MaxSizeSnow = 100;
    const int MaxTimeSun = 70;
    const int MaxTimeRain = 50;

    int total;
    float current;
    bool isSun;
    public ParticleSystem psRain;
    public ParticleSystem psSnow;
    ParticleSystem pscurrent;
    //GameObject rain;

    void Start()
    {
        isSun = Utils.Random(0, 1) == 0;
        Utils.particleStartStop(psRain, false);
        Utils.particleStartStop(psSnow, false);
        initRain();
    }
    void initRain () {
        Utils.Log("Init Rain");
        if (pscurrent != null)
        {
            Utils.particleStartStop(pscurrent, false);
        }
        isSun = !isSun; 
        current = 0;
        total = Utils.Random(20, isSun ? MaxTimeRain : MaxTimeSun);
        if (isSun)
        {
            pscurrent = null;
        }
        else
        {
            if (Utils.Random(0, 2) == 0)
            {
                // rain
                int size = Utils.Random(50, MaxSizeSnow);
                //
                var rate = new ParticleSystem.MinMaxCurve();
                rate.constantMax = size;
                var em = psRain.emission;
                em.rate = rate;
                //
                pscurrent = psSnow;
                Utils.particleStartStop(psSnow, true);
            }
            else
            {
                // rain
                int size = Utils.Random(50, MaxSizeRain);
                //
                var rate = new ParticleSystem.MinMaxCurve();
                rate.constantMax = size;
                var em = psRain.emission;
                em.rate = rate;
                //
                pscurrent = psRain;
                Utils.particleStartStop(psRain, true);
            }
        }
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
