using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runner
{
    public class WinOrDeathScreen : MonoBehaviour
    {
        [SerializeField] TMP_Text _text;
        [SerializeField] Button _menuButton;
        [SerializeField] Button _restartButton;

        private void Start()
        {
            _menuButton.onClick.AddListener(BackToMenu);
            _restartButton.onClick.AddListener(Restart);
        }

        public void WinOrDeath(bool win)
        {
            if (win)
            {
                _text.text = "You are won!";
                _text.color = Color.green;
            }
            else
            {
                _text.text = "You are dead!";
                _text.color = Color.red;
            }
        }
        private void BackToMenu()
        {
            SceneManager.LoadScene("Menu");
        } 

        private void Restart()
        {
            SceneManager.LoadScene("Runner");
        }
    }
}