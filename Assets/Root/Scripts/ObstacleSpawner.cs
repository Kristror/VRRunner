using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [SerializeField] private Transform[] _obstacle;
        [SerializeField] private float _spawnStep;
        [SerializeField] private float _spawnDistance;

        [SerializeField] private Vector2 _segmentWidht;

        private Transform _playerTransform;
        private Vector3 _lastPos;

        private List<Transform> _spawnedObstacles = new List<Transform>();
        public List<Transform> spawnedOdstacles 
        {
            get
            {
                _spawnedObstacles.RemoveAll(TransformIsNull);
                return _spawnedObstacles;
            }
        }

        bool TransformIsNull(Transform elem)
        {
            return elem == null;
        }

        void Start()
        {
            _playerTransform = transform;
            _lastPos = _playerTransform.position;
        }

        void Update()
        {
            if(_playerTransform.position.z > _lastPos.z + _spawnStep)
            {
                _lastPos.z += _spawnStep;

                Transform newObstacle = _obstacle[Random.Range(0, _obstacle.Length)];

                _spawnedObstacles.Add(Instantiate(newObstacle, new Vector3(
                    Random.Range(_segmentWidht.x, _segmentWidht.y),
                    0, _lastPos.z + _spawnDistance),
                    Quaternion.identity));
            }
        }
    }
}