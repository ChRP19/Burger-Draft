using Code.Infrastructure.AssetManager;
using Code.Player;
using Code.StaticData;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetsProvider;
        private readonly IStaticDataService _staticDataService;
        //private readonly IPersistentProgressService _progressService;

        public GameObject PlayerGameObject { get; set; }

        public GameFactory(IAssetProvider assetsProvider, IStaticDataService staticDataService)
        {
            _assetsProvider = assetsProvider;
            _staticDataService = staticDataService;
            //_progressService = progressService;
        }
        public GameObject CreatePlayer(GameObject at)
        {
            PlayerData playerData = _staticDataService.GetData();
            PlayerGameObject = InstantiateRegistered(AssetPath.PlayerPath, at.transform.position);

            PlayerGameObject.GetComponent<PlayerMove>().HorizontalSpeed = playerData.HorizontalSpeed;
            PlayerGameObject.GetComponent<PlayerMove>().ForwardSpeed = playerData.ForwardSpeed;

            return PlayerGameObject;
        }
        #region CreateHud
        //public GameObject CreateHud() =>
        //    InstantiateRegistered(AssetPath.HudPath);
        #endregion
        #region Create Ingredient
        //public GameObject CreateMonster(MonsterTypeId typeId, Transform parent)
        //{
        //    MonsterStaticData monsterData = _staticData.ForMonster(typeId);
        //    GameObject monster = Object.Instantiate(monsterData.Prefab, parent.position, Quaternion.identity, parent);

        //    IHealth health = monster.GetComponent<IHealth>();
        //    health.Current = monsterData.Hp;
        //    health.Max = monsterData.Hp;

        //    monster.GetComponent<ActorUI>().Construct(health);
        //    monster.GetComponent<AgentMoveToHero>().Construct(PlayerGameObject.transform);
        //    monster.GetComponent<NavMeshAgent>().speed = monsterData.MoveSpeed;

        //    LootSpawner lootSpawner = monster.GetComponentInChildren<LootSpawner>();
        //    lootSpawner.SetLoot(monsterData.MinLoot, monsterData.MaxLoot);
        //    lootSpawner.Construct(this, _randomService);

        //    Attack attack = monster.GetComponent<Attack>();
        //    attack.Construct(PlayerGameObject.transform);
        //    attack.Damage = monsterData.Damage;
        //    attack.Cleavage = monsterData.Cleavage;
        //    attack.EffectiveDistance = monsterData.EffectiveDistance;

        //    monster.GetComponent<RotateToHero>()?.Construct(PlayerGameObject.transform);

        //    return monster;
        //}
        #endregion
        #region Create Loot
        //public LootPiece CreateLoot()
        //{
        //    LootPiece lootPiece = InstantiateRegistered(AssetPath.Loot).GetComponent<LootPiece>();

        //    lootPiece.Construct(_progressService.Progress.WorldData);

        //    return lootPiece;
        //}
        #endregion
        #region Cleanup
        //public void Cleanup()
        //{
        //    ProgressReaders.Clear();
        //    ProgressWriters.Clear();
        //}
        #endregion
        private GameObject InstantiateRegistered(string prefabPath, Vector3 at)
        {
            GameObject gameObject = _assetsProvider.Instantiate(prefabPath, at);
            //RegisterProgressWatchers(gameObject);
            return gameObject;
        }

        #region Register
        //public void Register(ISavedProgressReader progressReader)
        //{
        //    if (progressReader is ISavedProgress progressWriter)
        //        ProgressWriters.Add(progressWriter);

        //    ProgressReaders.Add(progressReader);
        //}
        #endregion

        #region private
        //private void RegisterProgressWatchers(GameObject gameObject)
        //{
        //    foreach (ISavedProgressReader progressReader in gameObject.GetComponentsInChildren<ISavedProgressReader>())
        //        Register(progressReader);
        //}
        //private GameObject InstantiateRegistered(string prefabPath)
        //{
        //    GameObject gameObject = _assets.Instantiate(prefabPath);
        //    RegisterProgressWatchers(gameObject);
        //    return gameObject;
        //}
        #endregion
    }
}