using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
