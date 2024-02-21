using System.Collections.Generic;
using Models;
using UnityEngine;

namespace Managers
{
    public class ButtonsManager : MonoBehaviour
    {
        public static ButtonsManager instance;
        
        
        private List<DisplayButton> _buttons = new List<DisplayButton>();

        private PoolManager _poolManager;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {
            _poolManager = PoolManager.instance;
        }

        public void CreateButton(ButtonModel model)
        {
            var button = _poolManager.GetButton();

            if (button == null)
            {
                return;
            }
            
            _buttons.Add(button);
            
            button.Init(model);
        }

        public void UpdateButton(ButtonModel model)
        {
            foreach (var button in _buttons)
            {
                if (button.ButtonModel.id == model.id)
                {
                    button.UpdateButton(model);
                    break;
                }
            }
        }

        public void RemoveButton(int id)
        {
            foreach (var button in _buttons)
            {
                if (button.ButtonModel.id == id)
                {
                    button.RemoveButton();
                    _buttons.Remove(button);
                    break;
                }
            }
        }

        public async void RefreshButtons(int id = 0)
        {
            if (id != 0)
            {
                foreach (var button in _buttons)
                {
                    if (button.ButtonModel.id == id)
                    {
                        button.UpdateButton(button.ButtonModel);
                    }
                }
            }
            else
            {
                var newButtons = await GameManager.instance.ButtonsController.GetAllButtons();
                foreach (var button in _buttons)
                {
                    button.RemoveButton();
                }
                _buttons.Clear();

                foreach (var buttonModel in newButtons)
                {
                    CreateButton(buttonModel);
                }
            }
        }
    }
}
