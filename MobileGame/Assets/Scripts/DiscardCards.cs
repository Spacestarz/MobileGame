using System.Collections.Generic;
using UnityEngine;

public class DiscardCards : CardPile
{
    public static DiscardCards Instance;

    public override void AddCard(Card cardToAdd)
    {
        cards.Add(cardToAdd);
        Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to discardpile");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        cards.Remove(cardToRemove);
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
