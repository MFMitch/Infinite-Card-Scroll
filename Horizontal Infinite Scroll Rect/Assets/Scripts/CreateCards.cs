using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateCards : MonoBehaviour
{
    public event Action<DisplayCard> OnCardCreate;

    [SerializeField] private CardSprites _sprites;
    [SerializeField] private Card[] _cardsToCreate;
    [SerializeField] private GameObject _cardPrefab;
    [SerializeField] private LayoutGroup _layout;

    private List<GameObject> _cards = new List<GameObject>();

    private void Start()
    {
        Create();
    }

    public void Create()
    {
        foreach (var card in _cardsToCreate)
        {
            Sprite sprite = _sprites.GetSprite(card);
            GameObject tempCard = GameObject.Instantiate(_cardPrefab, _layout.transform);
            tempCard.GetComponent<DisplayCard>().Init(card, sprite);
            _cards.Add(tempCard);
            OnCardCreate?.Invoke(tempCard.GetComponent<DisplayCard>());
        }
    }
}
