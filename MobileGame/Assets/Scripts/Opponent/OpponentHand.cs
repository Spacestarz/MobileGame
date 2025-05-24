using System.Collections.Generic;
using UnityEngine;

public class OpponentHand : CardPile
{
    public static OpponentHand instance;

    public Vector3 startAOpponent;
    public Vector3 StartBOpponent;

    private bool endingturnON = false;


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
        cardToAdd._CardOrigin = Card.CardOriginEnum.OpponentHand;
        var cardinstancescript = cardToAdd.GetComponent<CardInstance>();

        cardinstancescript.SetTextVisability(false);

       if (cardToAdd.IsUp())
        {
            //this card is face up, changing it to face down
            Debug.Log("facing up opponent change to DOWN");
            cardToAdd.SetCardFaceUp(false);
        }
        
        UpdateHandOpponent();

        //Debug.Log($"Removing {cardToAdd._suit} with rank {cardToAdd._rank} from PlayerhandCardsList");
        //GetCardInstance(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        base.RemoveCard(cardToRemove);
         Debug.LogWarning($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from OpponentHand");
        Debug.Log("Ending opponent turn");
        OpponentAi.Instance.EndAITurnDelay();
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

        if (Dropzone.Instance._IsTakingAChance == false)
        {
            Debug.LogWarning("takingachance is false checking if opponent can play card");
            TrackingTurns.Instance.CheckCardsVSDropZone();
            Debug.LogWarning("OpponentHand UpdateHandOpponent");
        }
    }
}

