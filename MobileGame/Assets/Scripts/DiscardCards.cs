using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.EventSystems.EventTrigger;

public class DiscardCards : CardPile
{
    public static DiscardCards Instance;

    public Dictionary<Card, CardInstance> _CardDictoDiscard = new Dictionary<Card, CardInstance>();

    private Card _card;
    private CardInstance _cardInstance;


    public static event Action<Card , CardInstance> OnAddedCardToDicto;

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

        OnAddedCardToDicto += OnAddedCardToDictonary;
    }

    public void OnAddedCardToDictonary(Card card, CardInstance cardInstance)
    {
        AddCard(card);
        if (_CardDictoDiscard.TryGetValue(card, out CardInstance foundCardInstance))
        {
            foundCardInstance.GoToDiscardLocation(); //this works but need to get that card player added like the ten to also go here
        }
        Debug.Log("onaddedcardtodicto");
    }

    public void addToDictonary(Card card, CardInstance cardInstance)
    {
        _CardDictoDiscard.Add(card, cardInstance);
        OnAddedCardToDicto?.Invoke(card, cardInstance);
    }

}
