using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Dungeon_han
{
    public class MenuButton : MonoBehaviour
    {
        [SerializeField] private GameObject _panel;
        private Button _menuButton;
        // Start is called before the first frame update
        void Start()
        {
            _menuButton = GetComponent<Button>();
            _menuButton.onClick.AddListener(openMenu);
        }

        private void openMenu()
        {
            Time.timeScale = 0;
            _panel.SetActive(true);
        }
      
    }
}

