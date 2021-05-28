using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeControllers
{
    public class Head : MonoBehaviour
    {
        [SerializeField] private Player Player;
        private Vector3 _offset;
        private float _horizontalRotation = 0f;
        public float _rotationSpeed = 10f;
        private float _speedToRotate = 0f;

        Quaternion quaternion;
        void Start()
        {
            _offset = transform.position - Player.transform.position;
        }

        void Update()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _horizontalRotation = -1;
                _speedToRotate = _rotationSpeed;
            }
            else if (Input.GetKey(KeyCode.E))
            {
                _horizontalRotation = 1;
                _speedToRotate = _rotationSpeed;
            }
            else
            {
                _horizontalRotation = 0;
                _speedToRotate = 0;
            }
            transform.position = Player.transform.position + _offset;
        }

        private void FixedUpdate()
        {
            transform.Rotate(transform.up * _horizontalRotation * _speedToRotate * Time.fixedDeltaTime);
        }
    }

}
