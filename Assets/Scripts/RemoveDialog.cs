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
        await GameManager.instance.ButtonsController.RemoveButton(int.Parse(inputField.text));
        
        Hide();
    }
}
