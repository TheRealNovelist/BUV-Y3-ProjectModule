using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Graphic))]
public class FlashColor : MonoBehaviour
{
    private Graphic _graphic => GetComponent<Graphic>();
    [SerializeField] private Color colorToFlash;
    [SerializeField] private float flashTime = 0.1f;
    [SerializeField] private float duration = 1f;

    private Color _initialColor;
    
    private void Awake()
    {
        _initialColor = _graphic.color;
    }

    public void Flash()
    {
        Sequence sequence = DOTween.Sequence();

        sequence.Append(_graphic.DOColor(colorToFlash, flashTime));
        sequence.Append(_graphic.DOColor(_initialColor, duration - flashTime));

        sequence.Play();
    }
}
