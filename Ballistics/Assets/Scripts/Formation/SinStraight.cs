using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinStraight : SteeringBehaviour
{
    private IKinematic character;
    

    public SinStraight(IKinematic character)
    {
        this.character = character;
    }

    public override SteeringOutput GetSteering()
    {
        SteeringOutput so = new SteeringOutput();
        so.velocity = new Vector3(1.0f, 0.0f, Mathf.Sin(character.transform.position.x)).normalized;
        Debug.Log("SteeringOutput: " + so.velocity);
        return so;

    }
}
