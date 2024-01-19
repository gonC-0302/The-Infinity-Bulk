using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

namespace Dungeon
{
    public class PlayerSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject _player;

        public void SpawnPlayer(int[,] map,int mapSizeX,int mapSizeY)
        {
            if (!_player)
            {
                return;
            }

            Position position;
            do
            {
                var x = RogueUtils.GetRandomInt(0, mapSizeX - 1);
                var y = RogueUtils.GetRandomInt(0, mapSizeY - 1);
                position = new Position(x, y);
            } while (map[position.X, position.Y] != 2);

            _player.transform.position = new Vector2(position.X, position.Y);
        }
    }
}