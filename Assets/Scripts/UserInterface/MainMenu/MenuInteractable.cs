using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
        protected string _interaction;

        protected string _name;
        protected Text _text;
        protected Color _defaultColor;

        [SerializeField]
        [Header("Text color when this item is highlighted.")]
        protected Color _highlightColor = new Color(0,0,0);
   

        protected virtual void Awake()
        {
            _name = gameObject.name;

            if (GetComponent<Text>() != null) _text = GetComponent<Text>();
            else _text = transform.Find("Text").GetComponent<Text>();

            _defaultColor = _text.color;
        }


        public virtual void Left()
        {
            
        }

        public virtual void Right()
        {
            
        }

        public virtual string Interact()
        {
            return _interaction;
        }

        public virtual void Highlight()
        {
            _text.color = _highlightColor;
        }

        public virtual void DisableHighlight()
        {
            _text.color = _defaultColor;
        }
    }
}

