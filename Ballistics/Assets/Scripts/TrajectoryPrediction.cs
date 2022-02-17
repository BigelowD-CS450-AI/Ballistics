using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryPrediction : MonoBehaviour
{
    [SerializeField] private Projectile projectile;
    LineRenderer lr; 
    public GameManager gm;

    public void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        lr.positionCount = 100;
    }


    public void Predict()
    {
        if (!gm.Launched)
        {
            if (projectile.CalcTimesToTarget() >= 0)
            {
                projectile.SetLaunchDirection();
                Vector3[] positions = new Vector3[lr.positionCount];
                positions[0] = projectile.transform.position;
                for (int i = 1; i < lr.positionCount; i++)
                {
                    float time = projectile.ttt * ((float)i / (float)lr.positionCount);
                    positions[i] = projectile.transform.position + projectile.launchDirection * projectile.launchSpeed * time + 0.5f * Physics.gravity * time * time;
                }
                lr.SetPositions(positions);
            }
            else
                Reset();
        }
    }

    public void Reset()
    {
        lr.positionCount = 0;
        lr.positionCount = 100;
    }
}
