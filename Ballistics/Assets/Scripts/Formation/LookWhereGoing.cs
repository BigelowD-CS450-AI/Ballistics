using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereGoing : SteeringBehaviour
{
    private Kinematic character;

    public LookWhereGoing(Kinematic character)
    {
        this.character = character;
    }

    public override SteeringOutput GetSteering()
    {
        SteeringOutput so = new SteeringOutput();
        so.angularVelocity = Mathf.Atan2(character.GetVelocity().x, character.GetVelocity().z);
        return so;

    }
}
