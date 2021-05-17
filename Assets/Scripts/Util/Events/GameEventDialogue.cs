using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UserInterface;
namespace GameEventManagment
{
    public class GameEventDialogue : MonoBehaviour
    {
        private EdwardManager _edManager;

        private void Start()
        {
            _edManager = FindObjectOfType<EdwardManager>();
        }

        public void Run(Edward.Voiceline voiceLine)
        {
            Debug.Log($"[Edward]: {voiceLine.message.ToString()}");
            _edManager.SetVoiceline(voiceLine);
        }
    }
}