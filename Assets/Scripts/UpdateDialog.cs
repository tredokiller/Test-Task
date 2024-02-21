using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDialog : DialogBase
{
    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_InputField idField;
    
    [SerializeField] private TMP_Dropdown color;
    
    [SerializeField] private Button applyButton;
    [SerializeField] private Button exitButton;

    private void OnEnable()
    {
        applyButton.onClick.AddListener(Update);
        exitButton.onClick.AddListener(Hide);
    }

    private void OnDisable()
    {
        applyButton.onClick.RemoveListener(Update);
        exitButton.onClick.RemoveListener(Hide);
    }
    
    private async void Update()
    {
        ButtonModel model = new ButtonModel
        {
            Color = ColorPicker.GetColor(color.value),
            text = inputField.text
        };


        bool success = int.TryParse(idField.text, out model.id);

        if (success == false)
        {
            return;
        }

        await GameManager.instance.ButtonsController.UpdateButton(model);
    }
}
