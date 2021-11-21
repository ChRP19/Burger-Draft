using Code.Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        public Game Game;

        [Inject]
        public void Construct(IGameFactory gameFactory)
        {
            Game = new Game(this, gameFactory);
        }
        private void Awake()
        {
            Application.targetFrameRate = 60;
            
            Game.StateMachine.Enter<BootstrapState>();
        }
    }
}