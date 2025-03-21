using System.Collections.Generic;
using UnityEngine;

public class OpponentHand : CardPile
{
    public static OpponentHand instance;

    public Vector3 startAOpponent;
    public Vector3 StartBOpponent;


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
        Debug.Log("OpponentHand is getting a card to their hand");
        base.AddCard(cardToAdd);
        var cardinstancescript = cardToAdd.GetComponent<CardInstance>();

        cardinstancescript.SetTextVisability(false);

        if (Dropzone.Instance._IsTakingAChance == false)
        {
            UpdateHandOpponent();
        }
        //Debug.Log($"Removing {cardToAdd._suit} with rank {cardToAdd._rank} from PlayerhandCardsList");
        //GetCardInstance(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        base.RemoveCard(cardToRemove);
        // Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from PlayerhandList");
    }


    public void UpdateHandOpponent()
    {
        Debug.Log("Opponenthand Update");
        //make so it will update its position etc
        var objectcount = cards.Count;

        var A = startAOpponent;
        var B = StartBOpponent;

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

