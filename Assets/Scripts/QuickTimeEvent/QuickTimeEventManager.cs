using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Controls;
using System.Threading.Tasks;

namespace QuickTimeEvent
{
    public class QuickTimeEventManager : MonoBehaviour
    {

        private QuickTimeInputKey _activeInput;
        private int _numOfMistakes = 0;
        [SerializeField] private int _maxNumOfMistakes = 2;

        [SerializeField] private float _lifeSpan = 1.5f;
        [SerializeField] private int _numOfEvents = 5;
        [SerializeField] private int _delay = 150;

        private string _cutsceneLose = "FAIL";
        private string _cutsceneWin = "WIN";

        private InputManager _input;
        private QuickTimeEventUI _ui;

        [SerializeField]
        private Animator _armAnim;

        private QuickTimeInputKey _currentType;
        private bool _interactionCorrect = false;

        void Start()
        {
            _ui = FindObjectOfType<QuickTimeEventUI>();

            _input = FindObjectOfType<InputManager>();
            _input.InputMode += StartEvent;

        }

        private async void StartEvent(ControllerInputMode mode)
        {
            //Debug.Log("Starting QTE");
            // Check if the controller input is set correct
            if (mode != ControllerInputMode.QUICK_TIME)
            {
                return;
            }

            // Small delay before first ui element spawns
            await Task.Delay(250);
            _armAnim.SetTrigger("grabDrone");
            for (int i = 0; i <= _numOfEvents; ++i)
            {
                // spawn UI
                _currentType = RndKey();
                _ui.CreateQuickTimeDisplay(_currentType, _lifeSpan);

                // delay until ui element is destroyed
                await Task.Delay((int)Mathf.Floor(_lifeSpan * 1000 + 75));

                // check if player interacted
                if (!_interactionCorrect)
                {
                    _numOfMistakes++;
                    --i;
                    _interactionCorrect = false;
                }

                if (_numOfMistakes >= _maxNumOfMistakes)
                {
                    break;
                }

                // delay until next spawn
                await Task.Delay(_delay);
            }

            // Check Win / Lose
            if (_numOfMistakes >= _maxNumOfMistakes)
            {
                Debug.Log("YU FUKT UP S0N!!");
                // Do stuff / G A M E   O V E R
                // Obtain cutscene handler
                Cutscene.CutsceneHandler _cutsceneHandler = GameObject.Find("CutsceneManager").GetComponent<Cutscene.CutsceneHandler>();

                // Play cutscene
                _cutsceneHandler.StartCutscene(_cutsceneLose);

            }
            else
            {
                _input.SetInputMode(ControllerInputMode.MAIN_MENU);
                // Obtain cutscene handler
                Cutscene.CutsceneHandler _cutsceneHandler = GameObject.Find("CutsceneManager").GetComponent<Cutscene.CutsceneHandler>();

                // Play cutscene
                _cutsceneHandler.StartCutscene(_cutsceneWin);
            }
        }

        public bool CheckInteraction(QuickTimeInputKey type)
        {
            if (type == _currentType)
            {
                _interactionCorrect = true;
                return true;
            }
            return false;
        }

        private QuickTimeInputKey RndKey()
        {
            QuickTimeInputKey key;

            int index = Random.Range(0, 4);

            switch (index)
            {
                case 0:
                    key = QuickTimeInputKey.NORTH;
                    break;
                case 1:
                    key = QuickTimeInputKey.EAST;
                    break;
                case 2:
                    key = QuickTimeInputKey.SOUTH;
                    break;
                case 3:
                    key = QuickTimeInputKey.WEST;
                    break;
                default:
                    key = QuickTimeInputKey.NORTH;
                    Debug.LogError($"Wrong value wag given by randomizor: {index}");
                    break;
            }
            
            return key;
        }
    }
}
