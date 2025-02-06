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
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _PlayerHandcards.Remove(cardToRemove);
        Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from PlayerhandList");
    }

    void Update()
    {
       if (Input.GetKeyUp(KeyCode.P))
        {
            foreach (Card card in PlayerTableCards.instance._CardPlayerTable)
            {
                Debug.Log($"{card._suit} with rank {card._rank}");
            }
        }
    }


}
