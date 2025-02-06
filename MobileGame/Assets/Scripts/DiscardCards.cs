using System.Collections.Generic;
using UnityEngine;

public class DiscardCards : CardPile
{
    public static DiscardCards Instance;
    public List<Card> _DiscardsCards;

    public override void AddCard(Card cardToAdd)
    {
        _DiscardsCards.Add(cardToAdd);
        Debug.Log($"Adding {cardToAdd._suit} and rank {cardToAdd._rank} to discardpile");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _DiscardsCards.Remove(cardToRemove);
        Debug.Log($"Removing {cardToRemove._suit} and rank {cardToRemove._rank} from discardpile");
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
        _DiscardsCards = new List<Card>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
