using UnityEngine;
using System.Collections.Generic;

namespace Dungeon_han
{
    public class DungeonInitializer : MonoBehaviour
    {

        public const int MAP_SIZE_X = 20;
        public const int MAP_SIZE_Y = 20;

        public const int MAX_ROOM_NUMBER = 6;

        public GameObject _player;

        [SerializeField] private GameObject floorPrefab;
        [SerializeField] private GameObject wallPrefab;

        private int[,] map;

        void Start()
        {
            GenerateMap();
            SponePlayer();
        }

        private void GenerateMap()
        {
            map = new MapGenerator().GenerateMap(MAP_SIZE_X, MAP_SIZE_Y, MAX_ROOM_NUMBER);

            var floorList = new List<Vector3>();
            var wallList = new List<Vector3>();

            var floors = new GameObject("Floor");
            var walls = new GameObject("wall");


            for (int y = 0; y < MAP_SIZE_Y; y++)
            {
                for (int x = 0; x < MAP_SIZE_X; x++)
                {
                    if (map[x, y] == 1)
                    {
                        var floor = Instantiate(floorPrefab, new Vector2(x, y), new Quaternion());
                        floor.transform.SetParent(floors.transform);

                    }
                    else
                    {
                        var wall = Instantiate(wallPrefab, new Vector2(x, y), new Quaternion());
                        wall.transform.SetParent(walls.transform);

                    }
                }
            }

        }

        private void SponePlayer()
        {
            if (!_player)
            {
                return;
            }

            Position position;
            do
            {
                var x = RogueUtils.GetRandomInt(0, MAP_SIZE_X - 1);
                var y = RogueUtils.GetRandomInt(0, MAP_SIZE_Y - 1);
                position = new Position(x, y);
            } while (map[position.X, position.Y] != 1);

            _player.transform.position = new Vector2(position.X, position.Y);
        }
    }
}