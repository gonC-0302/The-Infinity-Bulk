using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dungeon
{
    public class AttackEffect : MonoBehaviour
    {
        private int _power;
        private float _shotPower = 10;

        public void Shot(int power, Vector2 dir)
        {
            var scale = transform.localScale;
            if (dir.x > 0)
            {
                scale.x *= -1;
                transform.localScale = scale;
            }
            if(dir == Vector2.zero)
            {
                dir = new Vector2(-1, 0);
            }
            this._power = power;
            var rb_eff = GetComponent<Rigidbody2D>();
            rb_eff.AddForce(dir * _shotPower, ForceMode2D.Impulse);
            Destroy(gameObject, 2.0f);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            var hitLayerName = LayerMask.LayerToName(collision.gameObject.layer);
            if (hitLayerName == "Enemy")
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            else if(hitLayerName == "Wall")
            {
                Destroy(gameObject);
            }
        }
    }
}