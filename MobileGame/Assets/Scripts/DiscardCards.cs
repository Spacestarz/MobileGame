using System.Collections.Generic;
using UnityEngine;

public class DiscardCards : CardPile
{
    public static DiscardCards Instance;

    public Dictionary<Card, CardInstance> _CardDictoDiscard = new Dictionary<Card, CardInstance>();

    private Card _card;
    private CardInstance _cardInstance;

    public override void AddCard(Card cardToAdd)
    {
        base.AddCard(cardToAdd);
       Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to discardpile");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        base.RemoveCard(cardToRemove);

        if (_CardDictoDiscard.TryGetValue(cardToRemove, out _cardInstance))
        {
            _CardDictoDiscard.Remove(cardToRemove);
            Debug.Log("removed card from the dropzone dictonary also");
        }

        Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from discardpile");
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        cards = new List<Card>();
    }

    public void OnAddedCardToDicto()
    {

    }

    //TODO have an observer is something is added in the dictonary to add it to the list also?
  

}
