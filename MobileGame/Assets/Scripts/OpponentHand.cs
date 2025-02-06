using System.Collections.Generic;
using UnityEngine;

public class OpponentHand : CardPile
{
    public static OpponentHand Instance;
    public List<Card> _OpponentHandCards;

    public override void AddCard(Card cardToAdd)
    {
        _OpponentHandCards.Add(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _OpponentHandCards.Remove(cardToRemove);
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


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

