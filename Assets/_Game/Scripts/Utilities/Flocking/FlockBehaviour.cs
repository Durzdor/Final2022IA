using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Utilities.Flocking
{
    public abstract class FlockBehaviour : MonoBehaviour
    {
        public abstract Vector3 CalculateDirection(List<Transform> context);
    }
}
