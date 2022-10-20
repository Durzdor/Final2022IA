using System.Collections.Generic;
using UnityEngine;

namespace _Game.Scripts.Utilities.Pathfinding
{
    public class AgentBFSDFS : MonoBehaviour
    {
        public LayerMask mask;
        public float distanceMax;
        public float radius;
        public Vector3 offset;
        public Node init;

        public Node finit;

        // modelo  public CI_Model pj;
        // caja?   public Box box;
        List<Node> _list;
        List<Vector3> _listVector;
        BFS<Node> _bfs = new BFS<Node>();
        DFS<Node> _dfs = new DFS<Node>();
        Dijkstra<Node> _djk = new Dijkstra<Node>();
        AStar<Node> _aStar = new AStar<Node>();
        AStar<Vector3> _aStarVector = new AStar<Vector3>();

        public void PathFindingBFS()
        {
            _list = _bfs.Run(init, Satisfies, GetNeighbours);
            // pj.SetWayPoints(_list);
            // box.SetWayPoints(_list);
        }

        public void PathFindingDFS()
        {
            _list = _dfs.Run(init, Satisfies, GetNeighbours);
            // pj.SetWayPoints(_list);
            // box.SetWayPoints(_list);
        }

        public void PathFindingDijkstra()
        {
            _list = _djk.Run(init, Satisfies, GetNeighbours, GetCost);
            // pj.SetWayPoints(_list);
            // box.SetWayPoints(_list);
        }

        public void PathFindingAStar()
        {
            _list = _aStar.Run(init, Satisfies, GetNeighbours, GetCost, Heuristic);
            // pj.SetWayPoints(_list);
            // box.SetWayPoints(_list);
        }

        public void PathFindingAStarVector()
        {
            _listVector = _aStarVector.Run(init.transform.position, SatisfiesVector, GetNeighboursVector, GetCostVector,
                HeuristicVector);
        }

        private float Heuristic(Node curr)
        {
            float cost = 0;
            // if (curr.hasTrap) cost += 5;
            cost += Vector3.Distance(curr.transform.position, finit.transform.position);
            return cost;
        }

        float HeuristicVector(Vector3 curr)
        {
            return Vector3.Distance(curr, finit.transform.position);
        }

        private float GetCostVector(Vector3 p, Vector3 c)
        {
            return 1;
        }

        List<Vector3> GetNeighboursVector(Vector3 curr)
        {
            List<Vector3> list = new List<Vector3>();
            for (int x = -1; x <= 1; x++)
            {
                for (int z = -1; z <= 1; z++)
                {
                    if (z == 0 && x == 0) continue;
                    var newPos = new Vector3(curr.x + x, curr.y, curr.z + z);
                    var dir = (newPos - curr);
                    if (Physics.Raycast(curr, dir.normalized, dir.magnitude, mask)) continue;
                    list.Add(newPos);
                }
            }

            return list;
        }

        bool SatisfiesVector(Vector3 curr)
        {
            return Vector3.Distance(curr, finit.transform.position) < 1;
        }

        private float GetCost(Node p, Node c)
        {
            return Vector3.Distance(p.transform.position, c.transform.position);
        }

        private List<Node> GetNeighbours(Node curr)
        {
            return curr.neighbours;
        }

        private bool Satisfies(Node curr)
        {
            return curr == finit;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            if (init != null) Gizmos.DrawSphere(init.transform.position + offset, radius);
            if (finit != null) Gizmos.DrawSphere(finit.transform.position + offset, radius);
            if (_list != null)
            {
                Gizmos.color = Color.blue;
                foreach (var item in _list)
                {
                    if (item != init && item != finit) Gizmos.DrawSphere(item.transform.position + offset, radius);
                }
            }

            if (_listVector != null)
            {
                Gizmos.color = Color.green;
                foreach (var item in _listVector)
                {
                    if (item != init.transform.position && item != finit.transform.position)
                        Gizmos.DrawSphere(item + offset, radius);
                }
            }
        }
    }
}