using TMPro;
using UnityEngine;

namespace Runner
{
    public class GoalPanel : MonoBehaviour
    {
        [SerializeField] private float _timeOnScreen = 3f;
        [SerializeField] private TMP_Text _goalText;
        [SerializeField] private WinController _winController;

        void Start()
        {
            _goalText.text = $"Survive for {_winController.Distance} meters";

            Destroy(gameObject, _timeOnScreen);
        }
    }
}