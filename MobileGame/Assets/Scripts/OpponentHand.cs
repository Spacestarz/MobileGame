using System.Collections.Generic;
using UnityEngine;

public class OpponentHand : CardPile
{
    public static OpponentHand Instance;
    public List<Card> _OpponentHandCards;

    public override void AddCard(Card cardToAdd)
    {
        _OpponentHandCards.Add(cardToAdd);
        Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to OpponentHandCards");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _OpponentHandCards.Remove(cardToRemove);
        Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from OpponentHandCards");
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
        _OpponentHandCards = new List<Card>();
    }


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

