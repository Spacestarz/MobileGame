using UnityEngine;
using System.Collections.Generic;

public class OpponentTableCard : CardPile
{
    public static OpponentTableCard Instance;
    public List<Card> _TableOpponentCards;

    public override void AddCard(Card cardToAdd)
    {
        _TableOpponentCards.Add(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _TableOpponentCards.Remove(cardToRemove);
    }

    private void Awake()
    {
        Debug.Log("opponentTABLEcards here");
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        _TableOpponentCards = new List<Card>();
    }
}
