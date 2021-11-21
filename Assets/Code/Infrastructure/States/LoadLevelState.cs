using Code.Camera;
using UnityEngine;

namespace Code.Infrastructure.States
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private const string StartPoint = "StartPoint";
        private const string IngredientSpawnerTag = "IngredientSpawner";
        private readonly IGameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(IGameStateMachine stateMachine, SceneLoader sceneLoader, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }
        public void Enter(string sceneName)
        {
            //_gameFactory.Cleanup();
            _sceneLoader.Load(sceneName, OnLoaded);
        }
        public void Exit()
        {

        }
        private void OnLoaded()
        {
            InitGameWorld();
            //InformProgressReaders();

            _stateMachine.Enter<GameLoopState>();
        }



        private void InitGameWorld()
        {
            // InitSpawners();
            GameObject hero = InitHero();

            // InitHud(hero);
            CameraFollow(hero);
        }
        private GameObject InitHero() =>
            _gameFactory.CreatePlayer(GameObject.FindWithTag(StartPoint));

        private void CameraFollow(GameObject hero) =>
            UnityEngine.Camera.main.GetComponent<CameraFollow>().Follow(hero);

        //private void InitSpawners()
        //{
        //    foreach (GameObject spawnerObject in GameObject.FindGameObjectsWithTag(EnemySpawnerTag))
        //    {
        //        EnemySpawner spawner = spawnerObject.GetComponent<EnemySpawner>();
        //        _gameFactory.Register(spawner);
        //    }
        //}

        #region
        //private void InformProgressReaders()
        //{
        //    foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
        //    {
        //        progressReader.LoadProgress(_progressService.Progress);
        //    }
        //}

        //private void InitHud(GameObject hero)
        //{
        //    GameObject hud = _gameFactory.CreateHud();

        //    hud.GetComponentInChildren<ActorUI>()
        //        .Construct(hero.GetComponent<HeroHealth>());
        //}


        #endregion
    }
}