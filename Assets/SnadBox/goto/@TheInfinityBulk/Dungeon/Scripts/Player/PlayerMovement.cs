using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private VariableJoystick variableJoystick;
        private Vector3 _scale = Vector3.one;
        private Vector2 _direction;
        [SerializeField] private bool _isJoyStick;
        Rigidbody2D _rigidbody2d;
        private Animator _anim;
       
        void Start()
        {
            _rigidbody2d = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
        }
        void Update()
        {
            // TODO: 攻撃アニメーションが終わるまではボタンを押せないようにする
            if (Input.GetKeyDown(KeyCode.Space)) _anim.SetTrigger("Attack");

            _direction = ReceiveMoveInput();
            if (_direction == Vector2.zero)
            {
                _anim.SetBool("IsWalking", false);
                return;
            }
            else
            {
                _anim.SetBool("IsWalking", true);
            }
            ChangeDirection();
        }
        private Vector3 ReceiveMoveInput()
        {
            Vector3 direction = Vector3.zero;
            if (_isJoyStick)
            {
                direction = Vector2.right * variableJoystick.Horizontal + Vector2.up * variableJoystick.Vertical;
            }
            else
            {
                float horizontal = Input.GetAxisRaw("Horizontal");
                float vertical = Input.GetAxisRaw("Vertical");
                direction = new Vector2(horizontal, vertical);
            }
            return direction;
        }
        private void ChangeDirection()
        {
            if (_direction.x == 0) return;
            if (_direction.x >= 0) _scale.x = -1;
            else _scale.x = 1;
            transform.localScale = _scale;
        }
        void FixedUpdate()
        {
            Move();
        }
        private void Move()
        {
            Vector2 position = _rigidbody2d.position;
            position.x = position.x + _speed * _direction.x * Time.deltaTime;
            position.y = position.y + _speed * _direction.y * Time.deltaTime;
            _rigidbody2d.MovePosition(position);
        }
    }
}