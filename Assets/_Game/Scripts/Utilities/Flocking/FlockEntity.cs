using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Utilities.Flocking
{
    public class FlockEntity : MonoBehaviour
    {
        public float _neighbourRadius = 4;

        private Vector3 _direction; 

        public Vector3 Direction {
            get {
                return _direction;
            }
        }
        public Collider _mainCollider; 

        private FlockBehaviour[] _steeringBehaviours;

        public LayerMask _mask;

    
        private void Awake()
        {
            _steeringBehaviours = GetComponents<FlockBehaviour>();
        
        }

        public Vector3 UpdateDirection() {

            Vector3 direction = Vector3.zero;

            List<Transform> context = GetNearbyEntities();

            for (int i = 0; i < _steeringBehaviours.Length; i++)
            {
                FlockBehaviour behaviour = _steeringBehaviours[i];

                direction += behaviour.CalculateDirection(context);
            }

            _direction = direction;

            return _direction;
        }

        public List<Transform> GetNearbyEntities() {

            List<Transform> context = new List<Transform>();

            Collider[] contextColliders = Physics.OverlapSphere(transform.position, _neighbourRadius, _mask);

            foreach(Collider collider in contextColliders)
            {
                if(collider != _mainCollider)
                {
                    context.Add(collider.transform);
                }
            }

            return context;
        }
    }
}