using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DialogBase : MonoBehaviour
{
    public void Show()
    {
        gameObject.SetActive(true);
        transform.DOScale(1, 0.3f);
    }

    public void Hide()
    {
        transform.DOScale(1, 0.3f).OnComplete((() => gameObject.SetActive(false)));
    }
}
