using System.Collections;
using UnityEngine;

namespace Runner
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private DeathScreen deathScreen;
        private Collider _playerCollider;

        void Start()
        {
            _playerCollider.GetComponent<Collider>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                deathScreen.gameObject.SetActive(true);
            }
        }
    }
}