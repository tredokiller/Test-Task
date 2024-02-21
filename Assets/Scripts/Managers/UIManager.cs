using System;
using Controllers;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Button createButton;
        [SerializeField] private Button deleteButton;
        [SerializeField] private Button updateButton;
        [SerializeField] private Button refreshButton;
        

        [SerializeField] private CreateDialog createDialog;
        [SerializeField] private UpdateDialog updateDialog;
        [SerializeField] private RemoveDialog removeDialog;


        private void OnEnable()
        {
            createButton.onClick.AddListener(OpenCreateDialog);
            deleteButton.onClick.AddListener(OpenDeleteDialog);
            updateButton.onClick.AddListener(OpenUpdateDialog);
            refreshButton.onClick.AddListener(Refresh);
        }

        private void OpenCreateDialog()
        {
            createDialog.Show();
        }

        private void OpenUpdateDialog()
        {
            updateDialog.Show();
        }

        public void OpenDeleteDialog()
        {
            removeDialog.Show();
        }

        public void Refresh()
        {
            ButtonsManager.instance.RefreshButtons();
        }
        
        
        
        
        private void OnDisable()
        {
            createButton.onClick.RemoveListener(OpenCreateDialog);
            deleteButton.onClick.RemoveListener(OpenDeleteDialog);
            updateButton.onClick.RemoveListener(OpenUpdateDialog);
            refreshButton.onClick.RemoveListener(Refresh);
        }
    }
}
