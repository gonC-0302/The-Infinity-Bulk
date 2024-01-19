using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
    [RequireComponent(typeof(PlayerAnimation))]
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerAttack : MonoBehaviour
    {
        private PlayerAnimation _anim;
        private PlayerMovement _movement;
        private int _power;
        [SerializeField] private AttackEffect _attackEffectPrefab;

        void Start()
        {
            _anim = GetComponent<PlayerAnimation>();
            _movement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) Attack();
        }

        public void Attack()
        {
            _anim.PlayAttackAnimation();
            var pos = transform.position;
            var rot = Quaternion.Euler(_movement.LastDirection);
            var eff = Instantiate(_attackEffectPrefab,pos,rot);
            eff.Shot(_power,_movement.LastDirection);
        }
    }
}