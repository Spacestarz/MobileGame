using System.Collections.Generic;
using UnityEngine;
using System;
using static UnityEngine.EventSystems.EventTrigger;

public class DiscardCards : CardPile
{
    public static DiscardCards Instance;

    private Card _card;
    private CardInstance _cardInstance;

    public override void AddCard(Card cardToAdd)
    {
        base.AddCard(cardToAdd);
        cardToAdd._CardOrigin = Card.CardOriginEnum.DiscardPile;
        var cardinstanceRef = cardToAdd.GetComponent<CardInstance>();
        cardinstanceRef.GoToDiscardLocation();
           
       Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to discardpile");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        base.RemoveCard(cardToRemove);

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
}
