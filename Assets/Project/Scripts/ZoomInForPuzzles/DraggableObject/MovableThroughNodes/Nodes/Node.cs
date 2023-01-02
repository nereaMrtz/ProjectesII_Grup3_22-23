using UnityEngine;

namespace Project.Scripts.ZoomInForPuzzles.DraggableObject.MovableThroughNodes.Nodes
{
    public class Node : MonoBehaviour
    {
        [SerializeField] private Node[] _nearNodes;

        public Node[] GetNodes()
        {
            return _nearNodes;
        }

        public void SetNodes(Node[] nodes)
        {
            _nearNodes = nodes;
        }
    }
}
