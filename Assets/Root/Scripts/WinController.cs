using UnityEngine;

namespace Runner
{
    public class WinController : MonoBehaviour
    {
        [SerializeField] private float _winDistance = 100f;
        [SerializeField] private WinOrDeathScreen _winOrDeath;
        [SerializeField] private Transform _winPoint;

        public float Distance
        {
            get => _winDistance;
        }
        private void Update()
        {
            if (transform.position.z >= _winDistance)
            {
                gameObject.GetComponent<CharController>().Death();
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;

                _winOrDeath.WinOrDeath(true);

                transform.position = _winPoint.position;
            }
        }
    }
}