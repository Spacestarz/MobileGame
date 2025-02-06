using System.Collections.Generic;
using UnityEngine;


public class PlayerHand : CardPile
{
    public List<Card> _PlayerHandcards;

    void Start()
    {
        _PlayerHandcards = new List<Card>();
    }

    public override void AddCard(Card cardToAdd)
    {
        _PlayerHandcards.Add(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _PlayerHandcards.Remove(cardToRemove);
    }

    void Update()
    {
        
    }
}
