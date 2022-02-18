using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seperate : SteeringBehaviour
{
    private IKinematic character;
    private IKinematic target;
    private float seperateDistance = 5.0f;

    public Seperate(IKinematic character, IKinematic target)
    {
        this.character = character;
        this.target = target;
    }

    public override SteeringOutput GetSteering()
    {
        SteeringOutput so = new SteeringOutput();
        if (Vector3.Distance(target.transform.position, character.transform.position) <= seperateDistance)
            so.velocity = (character.transform.position - target.transform.position).normalized;
        /*else
            so = null;*/
        return so;

    }
}
