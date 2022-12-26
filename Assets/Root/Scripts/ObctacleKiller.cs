using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class ObctacleKiller : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private ObstacleSpawner _spanwer;
        [SerializeField] private float _killDistance;

        void Update()
        {
            List<Transform> obstacles = _spanwer.spawnedOdstacles;

            for(int i = 0; i<obstacles.Count; i++)
            {
                if(_player.position.z > obstacles[i].position.z + _killDistance)
                {
                    Destroy(obstacles[i].gameObject);
                }
            }
        }
    }
}