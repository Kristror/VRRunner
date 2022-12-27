using UnityEngine;

namespace Runner
{
    public class PlayerCollision : MonoBehaviour
    {
        [SerializeField] private Transform _deathPoint;
        [SerializeField] private WinOrDeathScreen _winOrDeath;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Obstacle"))
            {
                gameObject.GetComponent<CharController>().Death();
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

                _winOrDeath.WinOrDeath(false);

                transform.position = _deathPoint.position;
            }
        }
    }
}