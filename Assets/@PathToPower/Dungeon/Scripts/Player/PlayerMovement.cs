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
        Rigidbody2D rigidbody2d;

        void Start()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
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

            if (_direction.x >= 0) _scale.x = 1;
            else _scale.x = -1;
            transform.localScale = _scale;
        }
        void FixedUpdate()
        {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + _speed * _direction.x * Time.deltaTime;
            position.y = position.y + _speed * _direction.y * Time.deltaTime;
            rigidbody2d.MovePosition(position);
        }
    }
}