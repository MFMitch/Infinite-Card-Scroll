using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollLocationCheck : MonoBehaviour
{
    public event Action OnTooFarRight;
    public event Action OnTooFarLeft;

    public bool tooFarRight;
    public bool tooFarLeft;

    public static float width;
    private float _maxOffset => transform.parent.childCount * (GetComponent<RectTransform>().rect.width / 1.5f);
    private float _startX;

    private void Start()
    {
        _startX = transform.parent.parent.position.x;
        width = GetComponent<RectTransform>().rect.width * 2;
    }

    private void Update()
    {
        if (transform.position.x > _startX + _maxOffset)
        {
            OnTooFarRight?.Invoke();
        }
        else if (transform.position.x < _startX - _maxOffset)
        {
            OnTooFarLeft?.Invoke();
        }
    }
}
