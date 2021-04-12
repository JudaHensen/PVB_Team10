using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainMenu
{
    public class Menu : MonoBehaviour
    {
        private string _name;

        private List<MenuInteractable> _interactables = new List<MenuInteractable>();
        private MenuInteractable _currentInteractable;
        private int _interactableIndex = 0;


        private void Start()
        {
            Debug.Log(GetComponent<RectTransform>().anchoredPosition.y);
            _name = gameObject.name;

            // Find all interactables
            foreach (Transform child in transform)
            {
                if (child.gameObject.GetComponent<MainMenu.MenuInteractable>() != null)
                {
                    _interactables.Add(child.gameObject.GetComponent<MainMenu.MenuInteractable>());
                }
            }

            // Set first interactable to interact with
            _currentInteractable = _interactables[_interactableIndex];
            _currentInteractable.Highlight();
        }
        
        public void SetActive()
        {
            _interactableIndex = 0;
            _currentInteractable = _interactables[_interactableIndex];

            //Debug.Log($"Active Menu: {_name}");
        }

        public void Next()
        {
            Debug.Log("Next interactable!");
            _currentInteractable.DisableHighlight();

            ++_interactableIndex;
            _interactableIndex %= _interactables.Count;

            _currentInteractable = _interactables[_interactableIndex];
            _currentInteractable.Highlight();
        }

        public void Previous()
        {
            Debug.Log("Previous interactable!");
            _currentInteractable.DisableHighlight();

            --_interactableIndex;
            if (_interactableIndex < 0) _interactableIndex = _interactables.Count - 1;

            _currentInteractable = _interactables[_interactableIndex];
            _currentInteractable.Highlight();
        }

        public void Left() { _currentInteractable.Left(); }

        public void Right() { _currentInteractable.Right(); }

        public string Interact() { return _currentInteractable.Interact(); }

        public Vector2 GetPosition()
        {
            RectTransform rect = GetComponent<RectTransform>();
            return new Vector2(rect.anchoredPosition.x, rect.anchoredPosition.y);
        }

        public string GetName() { return _name; }

    }
}

