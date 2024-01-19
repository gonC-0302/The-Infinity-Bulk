using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform _playerTran;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed = 3f;

    public void Init(Transform playerTran)
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerTran = playerTran;
    }
    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        Vector2 position = _rb.position;
        var direction = (_playerTran.position - transform.position).normalized;
        position.x = position.x + _speed * direction.x * Time.deltaTime;
        position.y = position.y + _speed * direction.y * Time.deltaTime;
        _rb.MovePosition(position);
    }
}
