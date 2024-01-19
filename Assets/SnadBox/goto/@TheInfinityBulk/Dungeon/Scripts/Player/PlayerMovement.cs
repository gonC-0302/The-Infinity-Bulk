using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
    [RequireComponent(typeof(PlayerAnimation))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed = 3f;
        [SerializeField] private VariableJoystick variableJoystick;
        private Vector3 _scale = Vector3.one;
        private Vector2 _direction;
        // 最後に入力した方向
        private Vector2 _lastDirection;
        public Vector2 LastDirection => _lastDirection;
        [SerializeField] private bool _isJoyStick;
        Rigidbody2D _rb;
        private PlayerAnimation _anim;
       
        void Start()
        {
            _anim = GetComponent<PlayerAnimation>();
            _rb = GetComponent<Rigidbody2D>();
        }
        void Update()
        {
            _direction = ReceiveMoveInput();
            if (_direction == Vector2.zero)
            {
                _anim.SwitchMoveAnimation(false);
                return;
            }
            else
            {
                _anim.SwitchMoveAnimation(true);
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

            // 最後に入力した情報を更新
            if(direction != Vector3.zero)
            {
                _lastDirection = direction;
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
            Vector2 position = _rb.position;
            position.x = position.x + _speed * _direction.x * Time.deltaTime;
            position.y = position.y + _speed * _direction.y * Time.deltaTime;
            _rb.MovePosition(position);
        }
    }
}