using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Card
{
    [SerializeField] private CardValue _value;
    [SerializeField] private CardSuit _suit;

    public CardValue value { get => _value; }
    public CardSuit suit { get => _suit; }
}
