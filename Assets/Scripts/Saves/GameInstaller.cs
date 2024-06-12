using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<ScoreHandler>().FromNew().AsSingle().NonLazy();
    }
}
