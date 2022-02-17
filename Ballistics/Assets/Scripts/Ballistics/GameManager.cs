using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool Launched = false;
    public void Launch()
    {
        Launched = true;
    }
    public void Reset()
    {
        Launched = false;
    }
    public void LoadDevelopment()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadProduction()
    {
        SceneManager.LoadScene(1);
    }
}
