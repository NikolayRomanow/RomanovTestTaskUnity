using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Game
{
    public abstract class Vehicle : MonoBehaviour
    {
        private Outline _outline;
        public Outline Outline => _outline;

        private float _speed = 10f;

        private void Awake()
        {
            _outline = GetComponent<Outline>();
        }

        public void EnableOutlibe()
        {
            _outline.enabled = true;
        }

        public void DisbaleOutline()
        {
            _outline.enabled = false;
        }

        public void SetPosition(Vector3 startPosition)
        {
            transform.position = startPosition;
        }

        private void Update()
        {
            transform.position += Vector3.forward * _speed * Time.deltaTime;
        }
    }
}
