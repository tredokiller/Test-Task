using System;
using Managers;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreateDialog : DialogBase
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Dropdown color;
    
    [SerializeField] private Button applyButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        applyButton.onClick.AddListener(Create);
        exitButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        applyButton.onClick.RemoveListener(Create);
        exitButton.onClick.RemoveListener(Hide);
    }
    
    private async void Create()
    {
        ButtonModel model = new ButtonModel();
        model.Color = ColorPicker.GetColor(color.value);
        model.text = inputField.text;

        await GameManager.instance.ButtonsController.CreateButton(model);
        
        Hide();
    }
}
