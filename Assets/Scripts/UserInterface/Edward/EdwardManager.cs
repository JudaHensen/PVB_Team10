using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Subtitles
{
    public class EdwardManager : MonoBehaviour
    {
        [SerializeField]
        private float _subtitleEndOffset = 1f;

        private GameObject _edward;
        private Edward.Voiceline _currentVoiceline;
        private UserInterface.TextTypemachine _subtitles;

        public Action FinishedVoiceline;
        private CustomUtilities.Timer _timer;

        void Start()
        {
            _edward = transform.Find("Edward").gameObject;
            _subtitles = transform.Find("Subtitles").gameObject.GetComponent<UserInterface.TextTypemachine>();

            _subtitles.Clear();
        }

        public void SetVoiceline(Edward.Voiceline voiceline)
        {
            _currentVoiceline = voiceline;

            // Update edward


            if (voiceline.typeSpeed <= ((voiceline.displayTime - _subtitleEndOffset) / voiceline.message.Length)) _subtitles.TypeMessage(voiceline.message, voiceline.typeSpeed);
            else _subtitles.TypeMessage(voiceline.message, (voiceline.displayTime - _subtitleEndOffset) / voiceline.message.Length);

            _timer = new CustomUtilities.Timer(voiceline.displayTime);
            _timer.OnComplete += OnFinished;

        }

        private void Update()
        {
            if (_timer != null) _timer.Update();
        }

        private void OnFinished()
        {
            // Stop edward animation

            // Clear subtitles
            _subtitles.Clear();
            FinishedVoiceline();
        }

    }
}
