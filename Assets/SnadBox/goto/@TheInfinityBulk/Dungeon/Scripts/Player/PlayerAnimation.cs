using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animator _anim;
        public void PlayAttackAnimation()
        {
            _anim.SetTrigger("Attack");
        }
        public void SwitchMoveAnimation(bool isMoving)
        {
            _anim.SetBool("IsWalking", isMoving);
        }
    }
}