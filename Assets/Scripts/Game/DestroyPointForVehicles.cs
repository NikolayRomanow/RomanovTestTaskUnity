using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public class DestroyPointForVehicles : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Vehicle vehicle))
            {
                Destroy(vehicle.gameObject);
            }
    }
    }
}
