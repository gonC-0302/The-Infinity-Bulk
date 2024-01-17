using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon_han
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private VariableJoystick variableJoystick;
        private Vector3 _scale = Vector3.one;
        private Vector2 _direction;
        [SerializeField] private bool _isJoyStick;
        Rigidbody2D rigidbody2d;
        private Animator _animator;


        void Start()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        void Update()
        {
            Attack1();
            if (_isJoyStick)
            {
               
                _direction = Vector2.right * variableJoystick.Horizontal + Vector2.up * variableJoystick.Vertical;
            }
            else
            {
                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                _direction = new Vector2(horizontal, vertical);
            }
            if (_direction.x == 0) return;

            if (_direction.x >= 0)
            {
                _scale.x = 1;
            }
            else _scale.x = -1;
            //transform.localScale = _scale;
        }

        void FixedUpdate()
        {
            Vector2 position = rigidbody2d.position;
            Vector2 Pastposition = position;
            position.x = position.x + _speed * _direction.x * Time.deltaTime;
            position.y = position.y + _speed * _direction.y * Time.deltaTime;
            if (Pastposition == position)
            {
                _animator.SetBool("Walk", false);
            }
            else
            {
                rigidbody2d.MovePosition(position);
                _animator.SetBool("Walk", true);

            }

            transform.localScale = _scale;

        }

        //í èÌçUåÇ
        private void Attack1()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _animator.SetTrigger("Attack1");
            }
        }
    }
}