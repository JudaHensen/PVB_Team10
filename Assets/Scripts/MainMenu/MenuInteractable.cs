using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class MenuInteractable : MonoBehaviour
    {
        private string _name;

        private void Start()
        {
            _name = gameObject.name;
        }


        public virtual void Left()
        {
            Debug.Log("Left!");
        }

        public virtual void Right()
        {
            Debug.Log("Right!");
        }

        public virtual void Interact()
        {
            Debug.Log("Interact!");
        }

        public virtual void Highlight()
        {
            Debug.Log($"Highlighted: {_name}");
        }

    }
}

