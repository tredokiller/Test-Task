using System;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RemoveDialog : DialogBase
{
    [SerializeField] private TMP_InputField inputField;
    
    [SerializeField] private Button applyButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        applyButton.onClick.AddListener(Remove);
        exitButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        applyButton.onClick.RemoveListener(Remove);
        exitButton.onClick.RemoveListener(Hide);
    }
    
    private async void Remove()
    {
        try
        {
           var id = int.Parse(inputField.text);
            await GameManager.instance.ButtonsController.RemoveButton(id);
        }
        catch (Exception ex)
        { 
            // ignored
        }

        Hide();
    }
}
