using System;
using UnityEngine;

public class distributeCards : MonoBehaviour
{
   private CardManager cardManager;
   private PlayerHand playerHand;
   private CardUIHandler cardUIHandler;

    void Start()
    {
       cardManager = GetComponent<CardManager>();
       playerHand = GetComponent<PlayerHand>();
       cardUIHandler = GetComponent<CardUIHandler>();
    }
  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (cardManager.allCardsList.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, cardManager.allCardsList.Count);
                Distribute(randomIndex);
            }
        }
    }

    public void Distribute(int index)
    {
        if ( index >= 0 && index < cardManager.allCardsList.Count) //ensure index is valid
        {
            Card card = cardManager.allCardsList[index];
            Debug.Log($"Retrieving card. Suit: {card._suit} Rank: {card._rank}");

            //gets the visuals for the card.
            cardUIHandler.GetCardUI(card._rank, card._suit); //sending the suit and rank

            cardManager.allCardsList.Remove(card);
            //Debug.Log($"Removing suit {card._suit} rank: {card._rank}");

            playerHand.DistributeCard(card);
            //playerHand.PlayercardsList.Add(card); //player gets a card
            Debug.Log($"Player got suit {card._suit} rank: {card._rank}");

            // cardManager.DiscardList.Add(card);
            //Debug.Log($"Adding suit {card._suit} rank: {card._rank}");
        }
       
    }
}
