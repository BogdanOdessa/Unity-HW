using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MazeControllers
{
    public class Player : MonoBehaviour
    {

        private Rigidbody _body;

        [SerializeField] private float speed;

        [SerializeField] private float _rotationSpeed;

        [SerializeField] private float _jumpForce;

        private float vertical;

        private float horizontal;

        private bool _isGrounded;
        void Start()
        {

            _body = GetComponent<Rigidbody>();

        }

        void FixedUpdate()
        {
            vertical = Input.GetAxis("Vertical");
            horizontal = Input.GetAxis("Horizontal");
            if (Input.GetAxis("Jump") > 0)
            {
                if (_isGrounded)
                {
                    _body.AddForce(transform.up * _jumpForce);
                }
            }
            Vector3 velocity = (transform.forward * vertical) * speed * Time.fixedDeltaTime;
            velocity.y = _body.velocity.y;
            _body.velocity = velocity;
            transform.Rotate((transform.up * horizontal) * _rotationSpeed * Time.fixedDeltaTime);
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == ("Ground"))
            {
                _isGrounded = true;
            }
        }
        void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.tag == ("Ground"))
            {
                _isGrounded = false;
            }

            #region
            //{
            //    public float Speed = 3.0f;
            //    private Rigidbody _rigidbody;
            //    public float rotsp = 50f;
            //    private float moveHorizontal;
            //    private float moveVertical;

            //    [SerializeField]private float _rotationSpeed = 20f;
            //    private float _speedToRotate = 0f;
            //    public float _horizontalRotation = 0f;


            //    private void Start()
            //    {
            //        _rigidbody = GetComponent<Rigidbody>();
            //    }

            //    protected void Move()
            //    {
            //        moveHorizontal = Input.GetAxis("Horizontal");
            //        moveVertical = Input.GetAxis("Vertical");

            //        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            //        _rigidbody.AddForce(movement * Speed);


            //    }

            //    private void Update()
            //    {
            //        //if (Input.GetKey(KeyCode.Q))
            //        //{
            //        //    _horizontalRotation = -1;
            //        //    _speedToRotate = _rotationSpeed;
            //        //}
            //        //else if (Input.GetKey(KeyCode.E))
            //        //{
            //        //    _horizontalRotation = 1;
            //        //    _speedToRotate = _rotationSpeed;
            //        //}
            //        //else
            //        //{
            //        //    _horizontalRotation = 0;
            //        //    _speedToRotate = 0;
            //        //}
            //    }

            //    private void FixedUpdate()
            //    {
            //        //moveHorizontal = Input.GetAxis("Horizontal");
            //        //moveVertical = Input.GetAxis("Vertical");
            //        //_rigidbody.velocity = (transform.forward * moveVertical) * Speed * Time.fixedDeltaTime;
            //        //transform.Rotate((transform.up * moveHorizontal) * _rotationSpeed * Time.fixedDeltaTime);
            //        Move();
            //        //transform.Rotate(transform.up * _horizontalRotation * _rotationSpeed * Time.fixedDeltaTime);
            //    }
            #endregion
        }
    }

}
