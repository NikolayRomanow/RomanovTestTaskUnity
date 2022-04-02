using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Game
{
    public class SpawnPointForVehicles : MonoBehaviour
    {
        private VehicleResponser _vehicleResponser;

        [Inject]
        public void Construct(VehicleResponser vehicleResponser)
        {
            _vehicleResponser = vehicleResponser;
        }

        private void Awake()
        {
            _vehicleResponser.VehicleLoaded += InstantiateNewVehicle;
        }

        private void Start()
        {
            _vehicleResponser.StartLoadNewVehicle();
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out Vehicle vehicle))
            {
                _vehicleResponser.StartLoadNewVehicle();
            }
        }

        private void InstantiateNewVehicle(GameObject prefab)
        {
            Vehicle vehicle = Instantiate(prefab).GetComponent<Vehicle>();
                    vehicle.SetPosition(transform.position);
        }
    }
}
