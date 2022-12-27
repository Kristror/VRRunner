using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Runner
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] Button _startButton;
        [SerializeField] Button _exitButton;

        [SerializeField] GameObject _vrCamera;
        [SerializeField] GameObject _ordinaryCamera;


        private void Start()
        {
            _startButton.onClick.AddListener(StartGame);
            _exitButton.onClick.AddListener(Exit);
        }

        private void StartGame()
        {
            SceneManager.LoadScene("Runner");
        }

        private void Exit()
        {
            Application.Quit(0);
        }
    }
}