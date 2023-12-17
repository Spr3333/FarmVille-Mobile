using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollison : MonoBehaviour
{
    private ParticleSystem ps;

    [Header("Events")]
    public static Action<Vector3[]> OnWaterCollided;

    private void OnParticleCollision(GameObject other)
    {
        ps = GetComponent<ParticleSystem>();
        List<ParticleCollisionEvent> collisionEvents = new List<ParticleCollisionEvent>();

        int collisionAmt = ps.GetCollisionEvents(other, collisionEvents);

        Vector3[] collisionPos = new Vector3[collisionAmt];

        for (int i = 0; i < collisionAmt; i++)
        {
            collisionPos[i] = collisionEvents[i].intersection;
            //Debug.Log("Position:" + collisionPos[i]);
        }

        

        OnWaterCollided?.Invoke(collisionPos);
    }
}
