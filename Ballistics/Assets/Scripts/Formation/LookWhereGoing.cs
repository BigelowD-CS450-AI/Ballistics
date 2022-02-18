using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereGoing : SteeringBehaviour
{
    private IKinematic character;

    public LookWhereGoing(IKinematic character)
    {
        this.character = character;
    }

    public override SteeringOutput GetSteering()
    {
        SteeringOutput so = new SteeringOutput();
        so.angularVelocity = Mathf.Atan2(character.GetVelocityDirection().x, character.GetVelocityDirection().z) * Mathf.Rad2Deg;
        /*Debug.Log("Ang Vel" + so.angularVelocity);
        Debug.Log("x vel" + character.GetVelocity().x);
        Debug.Log("z vel" + character.GetVelocity().z);*/
        return so;

    }
}
