using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    [SerializeField] private Image _cardImage;
    private Card _card;

    public Card card { get => _card; }

    public void Init(Card card, Sprite sprite)
    {
        _card = card;
        _cardImage.sprite = sprite;
    }
}
