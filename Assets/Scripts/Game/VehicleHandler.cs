using System.Collections;
using System.Collections.Generic;
using UI;
using UnityEngine;
using Zenject;

namespace Game
{
    public class VehicleHandler : MonoBehaviour
    {
        private Vehicle _vehicleOnScreen;
        private UIContainer _uiConatiner;

        [Inject]
        public void Construct(UIContainer uIContainer)
        {
            _uiConatiner = uIContainer;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.TryGetComponent(out Vehicle vehicle))
                    {
                        SetVehicleOnScreen(vehicle);
                    }

                    else
                    {
                        _uiConatiner.DestroyPopup();
                    }
                }

                else
                {
                    _uiConatiner.DestroyPopup();
                }
            }
        }

        private void SetVehicleOnScreen(Vehicle vehicle)
        {
            if (_vehicleOnScreen != null)
            {
                _vehicleOnScreen.DisbaleOutline();
                _vehicleOnScreen = null;
            }

            _vehicleOnScreen = vehicle;
            _vehicleOnScreen.EnableOutlibe();
            _uiConatiner.CreateNewPopup(_vehicleOnScreen.name, _vehicleOnScreen.GetHashCode().ToString());
        }
    }
}
