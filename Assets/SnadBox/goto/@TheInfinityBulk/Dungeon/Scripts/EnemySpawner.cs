using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Dungeon
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _enemyPrefab;
        [SerializeField] private Transform _playerTran;

        public void SpawnEnemy(int[,] map, int mapSizeX, int mapSizeY)
        {
            for (int i = 0; i < 10; i++)
            {
                var enemy = Instantiate(_enemyPrefab);
                enemy.GetComponent<EnemyMovement>().Init(_playerTran);
                Position position;
                do
                {
                    var x = RogueUtils.GetRandomInt(0, mapSizeX - 1);
                    var y = RogueUtils.GetRandomInt(0, mapSizeY - 1);
                    position = new Position(x, y);
                } while (map[position.X, position.Y] != 2);
                enemy.transform.position = new Vector2(position.X, position.Y);
            }
        }
    }
}