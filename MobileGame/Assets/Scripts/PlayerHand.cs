using Mono.Cecil;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHand : CardPile
{
    public static PlayerHand instance;

    public Vector3 startAPlayer;
    public Vector3 StartBPlayer;

    public Vector3 StartCPlayer;
    public Vector3 StartDPlayer;

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
        base.AddCard(cardToAdd);
        cardToAdd.TagForCanBePickedUp(true);
        cardToAdd._CardOrigin = Card.CardOriginEnum.PlayerHand;

        cardToAdd.gameObject.name = "PlayerHandCards";
        GameObject parentObject = GameObject.Find("AllPlayerHandCards");
        cardToAdd.gameObject.transform.SetParent(parentObject.transform, false);

        cardToAdd.SetCardFaceUp(true);
        UpdateHand();
        //Debug.Log($"Removing {cardToAdd._suit} with rank {cardToAdd._rank} from PlayerhandCardsList");
        //GetCardInstance(cardToAdd);
    }

    public override void RemoveCard(Card cardToRemove)
    {
        cardToRemove.transform.SetParent(null);//removing the parent
        cardToRemove.gameObject.name = $"{cardToRemove._suit} rank {cardToRemove._rank}"; 
        Debug.Log("removing card fom playerhand");
        base.RemoveCard(cardToRemove);
        // Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from PlayerhandList");
    }

    public void CheckIfLastPhase()
    {
        Debug.LogWarning("checkiflastphase method playerhand");

       if (cards.Count == 0)
        {
            Debug.LogWarning("activating last phase playerhand script row 58");
            LastPhase.Instance.StartEndPhase();
        }
    }


    public void UpdateHand()
    {
        //make so it will update its position etc
        var objectcount = cards.Count;

        if (objectcount >= 5)
        {
            //splitting cards first 6 cards are here and rest go to the second location.
            UpdateHandWithOverflow();
            return;
        }
        
        UpdateHandOriginalLocation(0,cards.Count);

        if (StartSwappingBeforeStart.instance._SwappingPhase == false)
        {
            TrackingTurns.Instance.CheckCardsVSDropZone();
        }
    }

    private void UpdateHandWithOverflow()
    {
        //placing first  6 cards in the orgin location
        UpdateHandOriginalLocation(0, 6);

        //placing remaining cards in the second location
        UpdateHandSecondLocation(6, cards.Count);

        if (StartSwappingBeforeStart.instance._SwappingPhase == false)
        {
            TrackingTurns.Instance.CheckCardsVSDropZone();
        }
    }

    private void UpdateHandOriginalLocation (int startIndex, int EndIndex)
    {

        if (EndIndex > cards.Count)
        {
            Debug.LogError($"EndIndex {EndIndex} is greater than cards.count {cards.Count}");
            EndIndex = cards.Count;
        }

        Debug.Log($"A position: {startAPlayer}");
        Debug.Log($"B position: {StartBPlayer}");
        Debug.Log($"Cards to place: {EndIndex - startIndex}");


        Debug.Log($"UpdateHandOriginalLocation: startIndex={startIndex}, endIndex={EndIndex}, cards.Count={cards.Count}");

        var A = startAPlayer;
        var B = StartBPlayer;

        Vector3 direction = (B - A).normalized;
        float totalDistance = Vector3.Distance(A, B);

        Debug.Log($"Total distance A to B: {totalDistance}");

        int cardCount = EndIndex - startIndex;
        float step = totalDistance / (cardCount + 1);

        Debug.Log($"Step size: {step}");

        for (int i = startIndex; i < EndIndex; i++)
        {
            Debug.Log($"Positioning card at index {i}");

            Vector3 position = A + direction * step * (i - startIndex + 1);

            Debug.Log($"Card {i} position: {position}");


            cards[i].transform.position = position;

            var cardinstance = cards[i].GetComponent<CardInstance>();
            cardinstance.UpdateOrgPos(position);

            // card.gameObject.transform.position = position;
        }
    }

    public void UpdateHandSecondLocation(int startIndex, int endIndex)
    {

        if (endIndex > cards.Count)
        {
            Debug.LogError($"EndIndex {endIndex} is greater than cards.count {cards.Count}");
            endIndex = cards.Count;
        }

        Debug.LogWarning("New locations for player caards");

        var C = StartCPlayer; 
        var D = StartDPlayer; 

        Vector3 direction = (D - C).normalized;
        float totalDistance = Vector3.Distance(C, D);


        int cardCount = endIndex - startIndex;
        float step = totalDistance / (cardCount + 1);


        for (int i = startIndex; i < endIndex; i++)
        {
            Debug.Log($"UpdateHandSecondLocation: startIndex={startIndex}, endIndex={endIndex}, cards.Count={cards.Count}");

            Vector3 position = C + direction * step * (i - startIndex + 1);

            cards[i].transform.position = position;

            var cardinstance = cards[i].GetComponent<CardInstance>();
            cardinstance.UpdateOrgPos(position);

            // card.gameObject.transform.position = position;
        }
       
    }
}
