using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitchGame : MonoBehaviour
{
    public void sceneSwitcher()
    {
        SceneManager.LoadScene(2);
    }
}
