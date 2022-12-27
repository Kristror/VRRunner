using TMPro;
using UnityEngine;

namespace Runner
{
    public class DistancePanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _distanceText;
        void Update()
        {
            _distanceText.text = $"{((int)transform.position.z)} m.";
        }
    }
}