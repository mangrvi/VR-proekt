using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObj : MonoBehaviour
{

    public Transform SpawnPoint;
    public GameObject Prefab;

    // Use this for initialization
    void onTriggerEnter(Collider P)
    {
        if (P.gameObject.tag == "Player")
        {
            Instantiate(Prefab, SpawnPoint.transform.position, SpawnPoint.transform.rotation);

        }
    }
}