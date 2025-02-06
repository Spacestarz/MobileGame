using System.Collections.Generic;
using UnityEngine;

public class OpponentHand : CardPile
{
    public List<Card> _OpponentHandCards;
    public override void AddCard(Card cardToAdd)
    {
        _OpponentHandCards.Add(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _OpponentHandCards.Remove(cardToRemove);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


public class OpponentTableCards : CardPile
{
     public List<Card> _TableOpponentCards;

    public override void AddCard(Card cardToAdd)
    {
        _TableOpponentCards.Add(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _TableOpponentCards.Remove(cardToRemove);
    }
}
