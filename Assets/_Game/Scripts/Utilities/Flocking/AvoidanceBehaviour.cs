using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Utilities.Flocking
{
    public class AvoidanceBehaviour : FlockBehaviour
    {
        public float personalSpaceRadius = 3;

        public override Vector3 CalculateDirection(List<Transform> context)
        {
            Vector3 direction = Vector3.zero;

            foreach (Transform item in context)
            {
                Vector3 offset = transform.position - item.transform.position;

                if (offset.magnitude < personalSpaceRadius)
                {

                    float scale = offset.magnitude / Mathf.Sqrt(personalSpaceRadius);

                    Vector3 forceVector = offset.normalized / scale;

                    direction += forceVector;
                }
            }

            return direction;
        }
    }
}
