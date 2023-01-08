using UnityEngine;
using UnityEngine.AI;

namespace Project.Scripts.Managers
{
    public class NavMeshManager : MonoBehaviour
    {
        private static NavMeshManager _instance;
        
        [SerializeField] private NavMeshSurface2d _navMeshSurface2d;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
            DontDestroyOnLoad(gameObject);
        }

        public static NavMeshManager Instance
        {
            get { return _instance; }
        }

        public void Bake()
        {
            _navMeshSurface2d.UpdateNavMesh(_navMeshSurface2d.navMeshData);
        }
    }
}
