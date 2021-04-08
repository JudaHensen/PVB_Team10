using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class MenuInteractable : MonoBehaviour
    {
        [SerializeField]
        [Header("LoadScene:[SCENENAME] to change scene to a different scene.")]

        [Space(-10)]
        [Header("OpenMenu:[MENUNAME] to change menu.")]
        
        [Space(-10)]
        [Header("Leave empty to do nothing.")]

        [Header("String of text that devines simple preprogrammed actions.")]
        private string _interaction;

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

        public virtual string Interact()
        {
            Debug.Log($"Interact! {_interaction}");
            return _interaction;
        }

        public virtual void Highlight()
        {
            //Debug.Log($"Highlighted: {_name}");
        }

        public virtual void DisableHighlight()
        {

        }
    }
}

