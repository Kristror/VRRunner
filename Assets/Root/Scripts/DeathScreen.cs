using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runner
{
    public class DeathScreen : MonoBehaviour
    {
        [SerializeField] Button _menuButton;
        [SerializeField] Button _restartButton;

        private void Start()
        {
            _menuButton.onClick.AddListener(BackToMenu);
            _restartButton.onClick.AddListener(Restart);

            gameObject.SetActive(false);
        }

        private void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        } 

        private void Restart()
        {
            SceneManager.LoadScene("Runner");
        }
    }
}