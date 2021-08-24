using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ButtonAnimation : MonoBehaviour
{
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    private void OnMouseEnter()
    {
        _image.transform.DOScale(1.1f, 0.3f);
    }

    private void OnMouseExit()
    {
        _image.transform.DOScale(1, 0.3f);
    }
}
