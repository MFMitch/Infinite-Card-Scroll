using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortCards : MonoBehaviour
{
    [SerializeField] private CreateCards _createCards;

    private List<DisplayCard> _displayCardObjects = new List<DisplayCard>(); 

    public List<DisplayCard> displayCardObjects { get => _displayCardObjects; }

    private void Awake()
    {
        _createCards.OnCardCreate += AddCardObject;
    }

    private void AddCardObject(DisplayCard card)
    {
        _displayCardObjects.Add(card);
        SortDisplayCardObjects();
    }

    private void SortDisplayCardObjects()
    {
        _displayCardObjects.Sort(DescendingCardSort);

        foreach (var cardObject in _displayCardObjects)
        {
            cardObject.transform.SetAsLastSibling();
        }
    }

    private int DescendingCardSort(DisplayCard card1, DisplayCard card2)
    {
        int suitCompare = card1.card.suit.CompareTo(card2.card.suit);

        if (suitCompare == 0)
        {
            return card2.card.value.CompareTo(card1.card.value);
        }
        else
        {
            return suitCompare;
        }
    }
}
