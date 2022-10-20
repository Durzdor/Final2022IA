using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Utilities.Flocking
{
    public class StayInRadiusBehaviour : FlockBehaviour
    {
        [SerializeField]
        private float radius = 10;
        public override Vector3 CalculateDirection(List<Transform> context)
        {
            Vector3 direction = Vector3.zero;            
            Vector3 center = Vector3.zero;            

            Vector3 centerOffset = center - this.transform.position;

            float df = centerOffset.magnitude / radius;

            if(df > .9f) {
                direction = centerOffset * df * df;
            }

            return direction;
        }
    }
}
