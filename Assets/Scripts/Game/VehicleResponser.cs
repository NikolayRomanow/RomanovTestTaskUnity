using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Game
{
    public class VehicleResponser : MonoBehaviour
    {
        public Action<GameObject> VehicleLoaded;

        [Header("To cars")]
        [SerializeField] private List<AssetReferenceT<GameObject>> carMeshesReferences;

        public void StartLoadNewVehicle()
        {
            carMeshesReferences[GetRandomIndexToLoadCar()].LoadAssetAsync().Completed += delegate (AsyncOperationHandle<GameObject> asyncOperationHandle)
            {
                switch (asyncOperationHandle.Status)
                {
                    case AsyncOperationStatus.Succeeded:
                        VehicleLoaded?.Invoke(asyncOperationHandle.Result);
                        break;
                }

                Addressables.Release(asyncOperationHandle);
            };
        }

        private int GetRandomIndexToLoadCar()
        {
            return UnityEngine.Random.Range(0, carMeshesReferences.Count - 1);
        }
    }
}
