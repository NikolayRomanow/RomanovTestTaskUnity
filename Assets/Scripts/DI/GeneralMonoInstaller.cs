using Game;
using UI;
using UnityEngine;
using Zenject;

namespace DI
{
    public class GeneralMonoInstaller : MonoInstaller
    {
        [SerializeField] private VehicleResponser vehicleResponcer; 
        [SerializeField] private SpawnPointForVehicles spawnPointForVehicles;
        [SerializeField] private DestroyPointForVehicles destroyPointForVehicles;
        [SerializeField] private VehicleHandler vehicleHandler;
        [SerializeField] private PopupScreen popupScreen;
        [SerializeField] private UIContainer uIContainer;

        public override void InstallBindings()
        {
            BindVehicleResponcer();
            BindSpawnPointForVehicles();
            BindDestroyPointForVehicles();
            BindPopupFactory();
            BindUIContainer();
            BindVehicleHandler();
        }

        private void BindVehicleResponcer()
        {
            VehicleResponser vehicleRes = Container.InstantiatePrefabForComponent<VehicleResponser>(vehicleResponcer);

            Container
                .Bind<VehicleResponser>()
                .FromInstance(vehicleRes)
                .AsSingle();
        }

        private void BindSpawnPointForVehicles()
        {
            SpawnPointForVehicles spawnPointForVehiclesOnScene = Container.InstantiatePrefabForComponent<SpawnPointForVehicles>(spawnPointForVehicles);

            Container
                .Bind<SpawnPointForVehicles>()
                .FromInstance(spawnPointForVehiclesOnScene)
                .AsSingle();
        }

        private void BindDestroyPointForVehicles()
        {
            DestroyPointForVehicles destroyPointForVehiclesOnScene = Container.InstantiatePrefabForComponent<DestroyPointForVehicles>(destroyPointForVehicles);

            Container
                .Bind<DestroyPointForVehicles>()
                .FromInstance(destroyPointForVehiclesOnScene)
                .AsSingle();
        }

        private void BindVehicleHandler()
        {
            VehicleHandler vehicleHandlerOnScene = Container.InstantiatePrefabForComponent<VehicleHandler>(vehicleHandler);

            Container
                .Bind<VehicleHandler>()
                .FromInstance(vehicleHandlerOnScene)
                .AsSingle();
        }

        private void BindPopupFactory()
        {
            Container
                .BindFactory<PopupScreen, PopupScreen.Factory>()
                .FromComponentInNewPrefab(popupScreen)
                .AsSingle();
        }

        private void BindUIContainer()
        {
            UIContainer uIContainerOnScreen = Container.InstantiatePrefabForComponent<UIContainer>(uIContainer);

            Container
                .Bind<UIContainer>()
                .FromInstance(uIContainerOnScreen)
                .AsSingle();
        }
    }
}