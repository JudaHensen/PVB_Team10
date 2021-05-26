using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameEventManagment;
using System.Threading.Tasks;

namespace Subtitles
{
    public class Introduction_BovenWater : MonoBehaviour
    {
        [SerializeField] private int[] _dialoges;
        [Header("Delay between dialoges in miliseconds.")]
        [SerializeField] private int _dialogeDelay = 250;

        private GameEventManager _evtManager;
        private int _index = 0;

        void Start()
        {
            _evtManager = FindObjectOfType<GameEventManager>();

            FindObjectOfType<EdwardManager>().FinishedVoiceline += PlayIntroduction;

            PlayIntroduction();
        }

        private async void PlayIntroduction()
        {
            await Task.Delay(_dialogeDelay);

            GameEvent dia = new GameEvent(GameEventType.DIALOGUE, _dialoges[_index]);
            _evtManager.RunEvent(dia);

            ++_index;
            if (_index == _dialoges.Length)
            {
                FindObjectOfType<EdwardManager>().FinishedVoiceline -= PlayIntroduction;
                Destroy(this);
            }
        }

    }
}

