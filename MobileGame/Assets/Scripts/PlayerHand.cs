using Mono.Cecil;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHand : CardPile
{
    public static PlayerHand instance;

    public Vector3 startAPlayer;
    public Vector3 StartBPlayer;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        cards = new List<Card>();
    }

    public override void AddCard(Card cardToAdd)
    {
        Debug.Log("playerhand is getting a card");
        base.AddCard(cardToAdd);
        cardToAdd.FlipCard();
        UpdateHand();
        //Debug.Log($"Removing {cardToAdd._suit} with rank {cardToAdd._rank} from PlayerhandCardsList");
        //GetCardInstance(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        base.RemoveCard(cardToRemove);
       // Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from PlayerhandList");
    }

    public void GetCardInstance(Card card)
    {
        //var CardInstanceThing = MakeCards.Instance.CreateCardObject(card);
        //UpdateHand(card);
    }

    public void UpdateHand()
    {
        //make so it will update its position etc
        var objectcount = cards.Count;

        var A = startAPlayer;
        var B = StartBPlayer;

        Vector3 direction = (B - A).normalized;
        float totalDistance = Vector3.Distance(A, B);
        float step = totalDistance / (cards.Count + 1);

        for (int i = 0; i < cards.Count; i++)
        {
            Vector3 position = A + direction * step * (i + 1);

            cards[i].transform.position = position;
            // card.gameObject.transform.position = position;
        }

        //testing 
        TrackingTurns.Instance.CheckCardsVSDropZone();
    }
}
