using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWalk : MonoBehaviour
{

    public Transform vrCamera;
    public float toggleAngle = 30.0f;
    public float speed = 3.0f;
    public bool moveForward;
    public bool moveBackwards;

    public GameObject flower;
    public GameObject pillar1;
    public GameObject pillar2;
    public GameObject pillar3;
    public GameObject g1;
    public GameObject g2;
    public GameObject g3;
    public int count;

    public AudioSource[] sounds;
    public AudioSource p1;
    public AudioSource p2;
    public AudioSource p3;

    private CharacterController cc;

    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
         
        if (vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForward = true;
            moveBackwards = false;            
        }

        else if (vrCamera.eulerAngles.x <= 360 - toggleAngle && vrCamera.eulerAngles.x > 360 - 90)
        {
            moveBackwards = true;
            moveForward = false;
        }

        else
        {
            moveForward = false;
            moveBackwards = false;
        }

        if (moveForward)
        {
            Vector3 forward = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forward * speed);
        }

        if (moveBackwards)
        {
            Vector3 backwards = vrCamera.TransformDirection(Vector3.back);
            cc.SimpleMove(backwards * speed);
        }

        if(count == 3)
        {
            flower.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            Destroy(other.gameObject);
            count++;

            if(count == 1)
            {
                pillar1.SetActive(true);
                g2.SetActive(true);
                p1.Play();
            }
            if(count == 2)
            {
                pillar2.SetActive(true);
                g3.SetActive(true);
                p2.Play();
            }
            if(count == 3)
            {
                pillar3.SetActive(true);
                p3.Play();
            }
        }

        if (other.gameObject.CompareTag("light"))
        {
            Destroy(other.gameObject);
        }
    }
}