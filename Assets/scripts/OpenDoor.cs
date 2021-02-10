
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class OpenDoor : MonoBehaviour
{

    public Image imgCircle;
    //public UnityEvent gvrClick;
    public float totalTime = 2;
    bool gvrStatus;
    public float gvrTimer;

    public GameObject door;
    public GameObject btn;
    public float speed;

    public AudioSource[] sounds;
    public AudioSource plants;
    public AudioSource stone;

    private void Start()
    {
        gvrStatus = false;
        gvrTimer = 0F;

        sounds = GetComponents<AudioSource>();
        plants = sounds[0];
        stone = sounds[1];
    }

    void Update()
    {
        Vector3 pos = door.transform.position;
        Vector3 pos2 = btn.transform.position;


        if (gvrStatus)
        {
            gvrTimer += Time.deltaTime;
            imgCircle.fillAmount = gvrTimer / totalTime;

            if (pos.y > -33f)
            {
                door.transform.position = new Vector3(pos.x, pos.y - speed, pos.z);   
            }
            else
            {
                plants.Stop();
                
            }
        }
        
        if (gvrTimer > totalTime)
        {
            imgCircle.fillAmount = 0;
            if (pos2.x < 100f)
            {
                 btn.transform.position = new Vector3(pos2.x + 0.05f, pos2.y, pos2.z - 0.05f);
            }
        }
    }

    public void GvrOn()
    {
        gvrStatus = true;
        plants.Play();

    }

    public void GvrOff()
    {

        gvrStatus = false;
        //gvrTimer = 0F;
        if(imgCircle.fillAmount == 0)
        {
             stone.Play();
        }
        plants.Pause();
    }

}