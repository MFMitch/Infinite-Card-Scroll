using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfiniteScrollUpdateObjectLocations : MonoBehaviour
{

    [SerializeField] private CreateCards _createCards;
    [SerializeField] private LayoutGroup _layout;
    [SerializeField] private SortCards _sortCards;

    private List<DisplayCard> _sortedList;
    private int _indexer = 0;


    private void Awake()
    {
        _sortedList = _sortCards.displayCardObjects;
        _createCards.OnCardCreate += RegisterCardToEvent;
    }

    // When an object is created for this layout group this method is invoked
    private void RegisterCardToEvent(DisplayCard displayCard)
    {
        InfiniteScrollLocationCheck infiniteScrollLocationCheck;

        displayCard.TryGetComponent<InfiniteScrollLocationCheck>(out infiniteScrollLocationCheck);

        // If this object has a InfiniteScrollLocationCheck then listen for its position updates
        if (infiniteScrollLocationCheck != null)
        {
            infiniteScrollLocationCheck.OnTooFarLeft += MoveIndexerRight;
            infiniteScrollLocationCheck.OnTooFarRight += MoveIndexerLeft;
        }
    }

    // This is invoked when a InginiteScrollLocationCheck object detected that it is too far right
    private void MoveIndexerLeft()
    {
        _indexer -= 1;
        if (_indexer < 0)
        {
            _indexer = _sortedList.Count - 1;
        }
        UpdateSortedListLocations();
        Vector3 layoutPos = _layout.transform.position;
        layoutPos.x -= InfiniteScrollLocationCheck.width;
        _layout.transform.position = layoutPos;
    }

    // This is invoked when a InginiteScrollLocationCheck object detected that it is too far left
    private void MoveIndexerRight()
    {
        _indexer += 1;
        if (_indexer >= _sortedList.Count)
        {
            _indexer = 0;
        }
        UpdateSortedListLocations();
        Vector3 layoutPos = _layout.transform.position;
        layoutPos.x += InfiniteScrollLocationCheck.width;
        _layout.transform.position = layoutPos;
    }

    // Update the child location of each item in the sorted list according to _indexer
    private void UpdateSortedListLocations()
    {
        // Starting with the object we want on the left, we update all of the objects transorms child indexes
        for (int i = _indexer; i < _sortedList.Count; i++)
        {
            _sortedList[i].transform.SetAsLastSibling();
        }
        for (int i = 0; i < _indexer; i++)
        {
            _sortedList[i].transform.SetAsLastSibling();
        }
    }
}
