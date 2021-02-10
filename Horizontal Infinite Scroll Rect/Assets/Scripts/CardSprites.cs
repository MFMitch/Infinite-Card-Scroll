using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Card Sprites")]
public class CardSprites : ScriptableObject
{
    [SerializeField] private Sprite[] _hearts;
    [SerializeField] private Sprite[] _diamonds;
    [SerializeField] private Sprite[] _clubs;
    [SerializeField] private Sprite[] _spades;

    public Sprite GetSprite(Card card)
    {
        Sprite[] suit;
        if (card.suit == CardSuit.hearts)
        {
            suit = _hearts;
        }
        else if (card.suit == CardSuit.diamonds)
        {
            suit = _diamonds;
        }
        else if (card.suit == CardSuit.clubs)
        {
            suit = _clubs;
        }
        else if (card.suit == CardSuit.spades)
        {
            suit = _spades;
        }
        else
        {
            throw new System.Exception($"Suit not found : {card.suit.ToString()}");
        }

        return suit[(int) card.value];
    }
}
