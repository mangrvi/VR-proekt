using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OpenPanel : MonoBehaviour
{ 
    public Image imgCircle;
    public UnityEvent gvrClick;
    public float totalTime = 2;
    bool gvrStatus;
    public float gvrTimer;
    public AudioSource[] sounds;
    public AudioSource talk;
    public AudioSource woosh;

    public GameObject Panel;
    public GameObject fire;
	public GameObject menu;

    private void Start()
    {
        gvrStatus = false;
        gvrTimer = 0F;
        
    }

    void Update()
    {
        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgCircle.fillAmount = gvrTimer / totalTime;
            
            if(imgCircle.fillAmount == 1)
            {
                Panel.SetActive(false);
            }
                
        }
        
        if (gvrTimer > totalTime)
        {
            
            imgCircle.fillAmount = 0;
            gvrClick.Invoke();
            
        }

    }

    public void GvrOn()
    {
        if(fire.active == false)
        {
            fire.SetActive(true);
			menu.SetActive(true);
            woosh.Play();
        }
        
        gvrStatus = true;
        
        if(Panel.active == true)
        {
            talk.Play();
        }
        
    }

    public void GvrOff()
    {
        gvrStatus = false;
        gvrTimer = 0F;
        //imgCircle.fillAmount = 0;
        talk.Pause();
    }
}