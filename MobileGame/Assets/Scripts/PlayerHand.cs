using System.Collections.Generic;
using UnityEngine;


public class PlayerHand : CardPile
{
    public static PlayerHand instance;

    public List<Card> _PlayerHandcards;

    private void Awake()
    {
        if (instance != null && instance != this )
        {
            Destroy (gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad (gameObject);
        _PlayerHandcards = new List<Card>();
    }

    public override void AddCard(Card cardToAdd)
    {
        _PlayerHandcards.Add(cardToAdd);
        Debug.Log($"Removing {cardToAdd._suit} with rank {cardToAdd._rank} from PlayerhandCardsList");
        InstantiateCard(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _PlayerHandcards.Remove(cardToRemove);
        Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from PlayerhandList");
    }

    void Update()
    {
       
    }

    public void InstantiateCard(Card card)
    {
       MakeCards.Instance.CreateCardObject(card);
    }

    public void UpdateHand()
    {
        //make so it will update its position etc
    }


}
