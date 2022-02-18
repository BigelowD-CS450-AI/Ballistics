using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class BlendedSteeringBehaviour : SteeringBehaviour
{
    private Kinematic character;
    private Kinematic target;
    private float seperateDistance = 5.0f;
    List<SteeringBehaviour> steeringBehaviours;
    

    public BlendedSteeringBehaviour(Kinematic character, Kinematic target, List<SteeringBehaviour> steeringBehaviours)
    {
        this.character = character;
        this.target = target;
        this.steeringBehaviours = steeringBehaviours;
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

public struct WeightedSteeringBehaviour
{
    SteeringBehaviour steeringBehaviour;
    float weight;
}
