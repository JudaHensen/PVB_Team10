using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtilities;
using UnityEngine.SceneManagement;
using Controls;

namespace MainMenu
{
    public class Main : MonoBehaviour
    {
        private InputManager _input;

        [SerializeField]
        [Header("Minimum Joycon range to interact with sliders and buttons.")]
        private float _minimumInput = 0.1f;
        [SerializeField]
        [Header("Range other direction must be in to activate wanted direction to disable diagonal joystick interaction.")]
        private float _directionalRange = 0.1f;
        [SerializeField]
        [Header("Delay between changing buttons and slider values.")]
        private float _interactDelay = 0.15f;
        [SerializeField]
        private GameObject _menuScroll;

        private List<MainMenu.Menu> _menus = new List<MainMenu.Menu>();
        private Menu _currentMenu;
        private CustomUtilities.Timer _delay;


        void Start()
        {
            _input = GameObject.Find("InputHandler").GetComponent<InputManager>();

            _input.Interact += Interact;
            _input.AnyKey += LoadMainMenu;
            _input.Back += MenuBack;

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
            _currentMenu = _menus[0];
            _currentMenu.SetActive();
        }

        void Update()
        {
            // Update interaction delay timer
            _delay.Update();

            JoyconInteract();
        }
        void LoadMainMenu()
        {
            Debug.Log(_currentMenu.GetName());
            if (_currentMenu.GetName() == "Start")
            {
                Interact();
            }
        }

        private void MenuBack()
        {
            string menu = _currentMenu.GetName();

            switch (menu)
            {
                case "Main":
                    menu = "Start";
                    break;
                case "Credits":
                    menu = "Main";
                    break;
                default:
                    break;
            }

            for (int i = 0; i < _menus.Count; ++i)
            {
                if (_menus[i].GetName().ToLower() == menu.ToLower())
                {
                    _currentMenu.Deactivate();
                    _currentMenu = _menus[i];
                    _currentMenu.SetActive();
                    break;
                }
                else if (i == _menus.Count - 1) Debug.LogError($"Menu: {menu} does not exist!");
            }

            _menuScroll.GetComponent<MenuScroll>().ScrollTo(_currentMenu.GetPosition().y);
        }

        private void JoyconInteract()
        {
            Vector2 state = _input.StickLeft;
            // Fix left / right for better sliders.
            if (state.y >= _minimumInput  && Mathf.Abs(state.x) < _directionalRange && _delay.Completed()) Up(state);
            if (state.y <= -_minimumInput && Mathf.Abs(state.x) < _directionalRange && _delay.Completed()) Down(state);
            if (state.x <= -_minimumInput && Mathf.Abs(state.y) < _directionalRange && _delay.Completed()) Left(state);
            if (state.x >= _minimumInput  && Mathf.Abs(state.y) < _directionalRange && _delay.Completed()) Right(state);
        }

        private void Up(Vector2 axis)
        {
            _currentMenu.Next();
            _delay.Restart();
        }

        private void Down(Vector2 axis)
        {
            _currentMenu.Previous();
            _delay.Restart();
        }

        private void Left(Vector2 axis)
        {
            _currentMenu.Left();
            _delay.Restart();
        }

        private void Right(Vector2 axis)
        {
            _currentMenu.Right();
            _delay.Restart();
        }

        private void Interact()
        {
            Debug.Log("Interact!!!");
            if (_delay.Completed())
            {
                _delay.Restart();
                string action = _currentMenu.Interact();
                Debug.Log($"Received action: {action}");

                // Deteremine what the current interaction is, and act accordingly
                switch( action.Remove(action.IndexOf(":")).ToUpper() )
                {
                    case "LOADSCENE":
                        string scene = action.Substring(action.IndexOf(":") + 1);

                        switch (scene)
                        {
                            case "BovenWater":
                                _input.SetInputMode(ControllerInputMode.GAMEPLAY);
                                break;
                            default:
                                break;
                        }

                        SceneManager.LoadScene(scene);
                        break;
                    case "OPENMENU":
                        // Find Menu to scroll & change to
                        string menu = action.Substring(action.IndexOf(":") + 1);

                        for (int i = 0; i < _menus.Count; ++i)
                        {
                            Debug.Log(menu);
                            if(_menus[i].GetName().ToLower() == menu.ToLower())
                            {
                                _currentMenu.Deactivate();
                                _currentMenu = _menus[i];
                                _currentMenu.SetActive();
                                break;
                            }
                            else if (i == _menus.Count - 1) Debug.LogError($"Menu: {menu} does not exist!");
                        }

                        _menuScroll.GetComponent<MenuScroll>().ScrollTo(_currentMenu.GetPosition().y);
                        break;
                    case "CLOSEGAME":
                        Application.Quit();
                        break;
                }
                

            }
        }

    }
}

