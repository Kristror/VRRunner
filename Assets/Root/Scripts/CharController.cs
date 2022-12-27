using UnityEngine;

namespace Runner
{

    public class CharController : MonoBehaviour
    {
        [SerializeField] private GameObject _camera;
        [SerializeField] float _speed = 6f;
        [SerializeField] float _sideSpeed = 2;
        [SerializeField] float _deadZoneRoatition = 10;

        private Rigidbody _player;
        private bool _isDead = false;

        private void Start()
        {
            _player = GetComponent<Rigidbody>();
        }

        public void Death()
        {
            _isDead = true;
        }

        private void Update()
        {
            if (!_isDead)
            {
                Vector3 dir = _player.velocity;

                float cameraZ = _camera.transform.rotation.eulerAngles.z;

                if (cameraZ > _deadZoneRoatition && cameraZ < 180)
                {
                    dir.x = cameraZ * -1 * _speed * Time.deltaTime;
                }
                if (cameraZ > 180 && cameraZ <= 360 - _deadZoneRoatition)
                {
                    dir.x = (360 - cameraZ) * _speed * Time.deltaTime;
                }

                dir.x = Input.GetAxis("Horizontal") * _speed;
                dir.z = _speed;

                _player.velocity = dir;
            }
        }
    }
}