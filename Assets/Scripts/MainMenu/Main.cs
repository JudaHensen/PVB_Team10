using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtilities;

namespace MainMenu
{
    public class Main : MonoBehaviour
    {
        private InputManager _input;

        [SerializeField]
        [Header("Minimum Joycon range to interact with sliders and buttons.")]
        private float _minimumInput = 0.2f;
        [SerializeField]
        [Header("Delay between changing buttons and slider values.")]
        private float _interactDelay = 0.1f;

        private List<MainMenu.Menu> _menus = new List<MainMenu.Menu>();
        private Menu _currentMenu;
        private CustomUtilities.Timer _delay;


        void Start()
        {
            _input = GameObject.Find("InputHandler").GetComponent<InputManager>();

            _input.Move += JoyconInteract;
            _input.Interact += Interact;

            // Find all menu's
            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<MainMenu.Menu>() != null)
                {
                    _menus.Add(child.gameObject.GetComponent<MainMenu.Menu>());
                }
            }

            // Set first menu to interact with
            _delay = new CustomUtilities.Timer(_interactDelay);
            _currentMenu = _menus[1]; //<<<<<<<<<<<<<< set to 0
            _currentMenu.Announce();
        }


        private void JoyconInteract(Vector2 state)
        {
            if (_delay.Completed())
            {
                _delay.Restart();

                if (state.y <= _minimumInput) Up();
                if (state.y >= _minimumInput) Down();
                if (state.x <= _minimumInput) Left();
                if (state.x >= _minimumInput) Right();
            }
        }

        private void Up()
        {
            _currentMenu.Next();
        }

        private void Down()
        {
            _currentMenu.Previous();
        }

        private void Left()
        {
            _currentMenu.Left();
        }

        private void Right()
        {
            _currentMenu.Right();
        }

        private void Interact()
        {
            if (_delay.Completed())
            {
                _delay.Restart();
                _currentMenu.Interact();
            }
        }
        void Update()
        {
            _delay.Update();
        }

    }
}

