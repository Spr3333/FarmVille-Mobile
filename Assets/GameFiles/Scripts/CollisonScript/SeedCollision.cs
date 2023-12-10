using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedCollision : MonoBehaviour
{

    [Header("Elements")]
    private ParticleSystem ps;


    [Header("Events")]
    public static Action<Vector3[]> SeedCollidedEvent;
    private void OnParticleCollision(GameObject other)
    {
        ps = GetComponent<ParticleSystem>();
        List<ParticleCollisionEvent> collisonEvent = new List<ParticleCollisionEvent>();

        int collisionAmt = ps.GetCollisionEvents(other, collisonEvent);

        Vector3[] collisionPos = new Vector3[collisionAmt];

        for (int i = 0; i < collisionAmt; i++)
        {
            collisionPos[i] = collisonEvent[i].intersection;
        }

        SeedCollidedEvent?.Invoke(collisionPos);
    }
}
