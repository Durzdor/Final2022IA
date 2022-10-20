using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Utilities.Flocking
{
    public class CohesionBehaviour : FlockBehaviour
    {
        public override Vector3 CalculateDirection(List<Transform> context)
        {
            Vector3 direction = Vector3.zero;
            
            FlockEntity entity = GetComponent<FlockEntity>();
            Vector3 centerOfMass = Vector3.zero;

            if(context.Count > 0) 
            {
                foreach (Transform item in context)
                {
                    centerOfMass += item.position;
                }

                centerOfMass /= context.Count;

                direction = centerOfMass - transform.position;
            }

            return direction;
        }
    }
}
