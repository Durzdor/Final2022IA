using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Utilities.Pathfinding
{
    public class Node : MonoBehaviour
    {
        public List<Node> neighbours;
        public bool isTrap;
        private void Start()
        {
            GetNeighbour(Vector3.right);
            GetNeighbour(Vector3.left);
            GetNeighbour(Vector3.forward);
            GetNeighbour(Vector3.back);
        }
        void GetNeighbour(Vector3 dir)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit, 2.2f))
            {
                neighbours.Add(hit.collider.GetComponent<Node>());
            }
        }
    }
}
