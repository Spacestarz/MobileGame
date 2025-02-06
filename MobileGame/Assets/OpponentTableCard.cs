using UnityEngine;
using System.Collections.Generic;

public class OpponentTableCard : CardPile
{
    public static OpponentTableCard Instance;
    public List<Card> _TableOpponentCards;

    public override void AddCard(Card cardToAdd)
    {
        _TableOpponentCards.Add(cardToAdd);
        Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to TableOpponentCards");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _TableOpponentCards.Remove(cardToRemove);
        Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from TableOpponentCards");
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
