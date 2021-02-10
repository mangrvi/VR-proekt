using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class gvrButton : MonoBehaviour {

    public Image imgCircle;
    public UnityEvent gvrClick;
    public float totalTime = 2;
    bool gvrStatus;
    public float gvrTimer;

    private void Start()
    {
        gvrStatus = false;
        gvrTimer = 0F;
    }

    void Update () {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgCircle.fillAmount = gvrTimer / totalTime;
        }
        if(gvrTimer > totalTime)
        {
            imgCircle.fillAmount = 0;
            gvrClick.Invoke();
        }
		
	}

    public void GvrOn()
    {
        gvrStatus = true;
    }

    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0F;
        imgCircle.fillAmount = 0;
    }
}
