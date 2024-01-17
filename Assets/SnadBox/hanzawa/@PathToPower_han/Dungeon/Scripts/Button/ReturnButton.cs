using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



namespace Dungeon_han
{
    public class ReturnButton : MonoBehaviour

    {
        [SerializeField] private GameObject _panel;
        private Button _returnButton;
        // Start is called before the first frame update
        void Start()
        {
            _returnButton = GetComponent<Button>();
            _returnButton.onClick.AddListener(CloseMenu);
        }

        private void CloseMenu()
        {
            Time.timeScale = 1;
            _panel.SetActive(false);
        }

    }
}

