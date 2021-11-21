using Code.Infrastructure;
using Code.Infrastructure.States;
using Code.Player;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Code.UI
{
    public class UIManager : MonoBehaviour
    {
        public Button StartButton;
        private IGameFactory _gameFactory;
        private GameBootstrapper _gameBootstrapper;

        [Inject]
        public void Construct(IGameFactory gameFactory, GameBootstrapper gameBootstrapper)
        {
            _gameFactory = gameFactory;
            _gameBootstrapper = gameBootstrapper;
        }

        private void Awake()
        {
            StartButton.gameObject.SetActive(true);
        }

        public void StartGame()
        {
            StartButton.gameObject.SetActive(false);
            _gameFactory.PlayerGameObject.GetComponent<PlayerMove>().enabled = true;
        }

        public void RestartGame()
        {
            // _gameBootstrapper.Game.StateMachine.Enter<LoadLevelState, string>("Main");
            _gameBootstrapper.Game.StateMachine.Enter<BootstrapState>();
        }
    }
}