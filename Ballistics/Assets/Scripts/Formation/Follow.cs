using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : SteeringBehaviour
{
    private IKinematic character;
    private IKinematic target;

    public Follow(IKinematic character, IKinematic target)
    {
        this.character = character;
        this.target = target;
    }

    public override SteeringOutput GetSteering()
    {
        SteeringOutput so = new SteeringOutput();
        so.velocity = (target.transform.position - character.transform.position).normalized;
        return so;

    }
}
