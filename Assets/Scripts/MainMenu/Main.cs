using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CustomUtilities;
using UnityEngine.SceneManagement;

namespace MainMenu
{
    public class Main : MonoBehaviour
    {
        private InputManager _input;

        [SerializeField]
        [Header("Minimum Joycon range to interact with sliders and buttons.")]
        private float _minimumInput = 0.1f;
        [SerializeField]
        [Header("Delay between changing buttons and slider values.")]
        private float _interactDelay = 0.15f;

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
            _currentMenu.SetActive();
        }

        void Update()
        {
            // Update interaction delay timer
            _delay.Update();
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
                string action = _currentMenu.Interact();
                Debug.Log($"Received action: {action}");

                // Deteremine what the current action means, and act accordingly
                //<<<<<<< Check if switch checks correct part of the string!<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                switch( action.Remove(action.IndexOf(":")).ToUpper() )
                {
                    case "LOADSCENE":
                        string scene = action.Substring(action.IndexOf(":") + 1);
                        Debug.Log($"Loading scene: {scene}");
                        SceneManager.LoadScene(scene);
                        break;
                    case "OPENMENU":
                        // Find Menu to scroll & change to
                        string menu = action.Substring(action.IndexOf(":") + 1);

                        for (int i = 0; i < _menus.Count; ++i)
                        {
                            if(_menus[i].GetName().ToLower() == menu.ToLower())
                            {
                                _currentMenu = _menus[i];
                                break;
                            }
                            else
                            {
                                if (i == _menus.Count-1) Debug.LogError($"Menu: {menu} does not exist!");
                            }
                        }

                        Debug.Log($"Scrolling to menu: {menu}");
                        GetComponent<MenuScroll>().ScrollTo(_currentMenu.GetPosition().y);
                        break;
                    case "CLOSEGAME":
                        Application.Quit();
                        break;
                }
                

            }
        }

    }
}

