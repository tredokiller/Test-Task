using System;
using DG.Tweening;
using Models;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class DisplayButton : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI text;
    private Button _button;

    public ButtonModel ButtonModel { private set; get; }

    private Sequence _animationSequence;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    public void Init(ButtonModel model)
    {
        ButtonModel = model;
        
        UpdateData();
        
        gameObject.SetActive(true);
        transform.localScale = Vector3.zero;

        transform.DOScale(1, 0.5f).OnComplete((() =>
        {
            if (ButtonModel.hasAnimation)
            {
                AnimateButton();
            }
        }));
    }

    public void UpdateButton(ButtonModel model)
    {
        _animationSequence.Kill();

        ButtonModel = model;

        transform.DOScale(1, 0.5f);
        
        if (ButtonModel.hasAnimation)
        {
            AnimateButton();
        }
    }

    public void RemoveButton()
    {
        _animationSequence.Kill();
        transform.DOScale(0, 0.15f).OnComplete((() => gameObject.SetActive(false)));
    }

    private void AnimateButton()
    {
        Sequence mySequence = DOTween.Sequence();
        
        mySequence.Append(transform.DOScale(0.8f, 0.2f));
        
        mySequence.Append(transform.DOScale(1.2f, 0.2f));
        mySequence.SetLoops(-1, LoopType.Yoyo);
    }

    private void UpdateData()
    {
        text.text = ButtonModel.text;
        image.color = new Color(ButtonModel.Color[0], ButtonModel.Color[1], ButtonModel.Color[2]);
    }
    
    
}
