using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenBtn : MonoBehaviour
{
    [SerializeField] private Sprite spriteOn;
    [SerializeField] private Sprite spriteOff;
    private Image _btnImage;

    private bool _isOn = true;

    private void Start()
    {
        _btnImage = GetComponent<Image>();
        SetSprite();
    }

    public void ToggleSprite()
    {
        _isOn = !_isOn;
        SetSprite();
    }

    private void SetSprite()
    {
        _btnImage.sprite = _isOn ? spriteOn : spriteOff;
    }


}