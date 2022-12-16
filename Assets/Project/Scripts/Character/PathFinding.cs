using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts.Character
{
    public class PathFinding : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        private NavMeshAgent _agent;
        
        
        // Start is called before the first frame update
        void Start()
        {
            _agent = gameObject.GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;
        }

        // Update is called once per frame
        void Update()
        {
            _agent.SetDestination(_target.position);
        }
    }
}
