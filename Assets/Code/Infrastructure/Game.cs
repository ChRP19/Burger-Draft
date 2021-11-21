namespace Code.Infrastructure
{
    public class Game
    {
        public IGameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, IGameFactory gameFactory)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), gameFactory);
        }
    }
}