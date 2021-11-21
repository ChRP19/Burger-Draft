using Zenject;

namespace Code.Infrastructure.Installers
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            //Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
        }
    }
}
