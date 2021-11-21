using Code.Infrastructure.AssetManager;
using Zenject;

namespace Code.Infrastructure.Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public GameBootstrapper GameBootstrapper;
        public override void InstallBindings()
        {
            InstallGameFactory();
            InstallAssetProvider();
            InstallStaticData();
            
            InstallGameBootstrapper();
        }

        private void InstallGameBootstrapper() => 
            Container.Bind<GameBootstrapper>().FromInstance(GameBootstrapper).AsSingle();

        private void InstallGameFactory() => 
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        private void InstallAssetProvider() => 
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();


        private void InstallStaticData()
        {
            IStaticDataService staticData = new StaticDataService();
            staticData.LoadData();
            Container.Bind<IStaticDataService>().FromInstance(staticData).AsSingle();
        }

        //private static IInputService InputServices()
        //{
        //    if (Application.isEditor)
        //        return new StandaloneInputServices();
        //    else
        //        return new TouchInputServices();
        //}
    }
}