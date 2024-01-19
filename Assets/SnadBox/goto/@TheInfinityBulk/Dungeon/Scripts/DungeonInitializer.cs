using UnityEngine;
using System.Collections.Generic;

namespace Dungeon
{
    public class DungeonInitializer : MonoBehaviour
    {
        [SerializeField] private int MAP_SIZE_X;
        [SerializeField] private int MAP_SIZE_Y;

        [SerializeField] private PlayerSpawner _playerSpawner;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private MapGenerator _mapGenerator;

        void Start()
        {
            var map = _mapGenerator.GenerateMap(MAP_SIZE_X, MAP_SIZE_Y);
            _playerSpawner.SpawnPlayer(map, MAP_SIZE_X, MAP_SIZE_Y);
            _enemySpawner.SpawnEnemy(map, MAP_SIZE_X, MAP_SIZE_Y);
        }
    }
}