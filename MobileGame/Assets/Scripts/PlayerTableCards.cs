using NaughtyAttributes;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTableCards : CardPile 
{
    public static PlayerTableCards instance;

    [SerializeField] List<GameObject> _TablePlayerLocations; 

    public override void AddCard(Card cardToAdd)
    {
        base.AddCard(cardToAdd);
        var cardInstanceScript = cardToAdd.GetComponent<CardInstance>();

        if (cards.Count <=3) 
            
            //Need to change this because when later when you add cards it will get the tag noninteractable
        {
            cardToAdd.TagNonInteractable();
            //changing parent and name for better visability in inspector 
            cardToAdd.gameObject.name = "TableCardPlayerUpsideDown";
            GameObject parentObject = GameObject.Find("PlayersCardTableFolder");
            cardToAdd.gameObject.transform.SetParent(parentObject.transform, false);
            // GetCardInstanceUpsideDown(cardToAdd);
            cardInstanceScript.SetTextVisability(false);
            Debug.Log("getting upside down card");
        }
        else
        {
            // change the card layeroption so it gets aboeve the upside down cards
            cardToAdd.TagForCanBePickedUp(false);

            //changing parent and name for better visability in inspector 
            cardToAdd.gameObject.name = "TableCardPlayerVisible";
            GameObject parentObject = GameObject.Find("PlayersCardTableFolder");
            cardToAdd.gameObject.transform.SetParent(parentObject.transform, false);

          

            GetCardInstance(cardToAdd);//updating table here
            cardToAdd.SetCardFaceUp(true); //3 should now be up
            Debug.Log("3 should be able to be visible");
           // Debug.Log("getting NORMAL card");
        }

    }

    public override void RemoveCard(Card cardToRemove)
    {
        Debug.Log($"Removing {cardToRemove._suit}  with rank  {cardToRemove._rank}  from PlayerTableCard");

        base.RemoveCard(cardToRemove);
    }

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

    //trying to make it like playerhand kinda
    public void GetCardInstance(Card card)
    {
      //  var CardInstanceThing = MakeCards.Instance.CreateCardObject(card);

        UpdateTable();
    }

    public void UpdateTable() 
    {
        int i = 0;

        foreach (var card in cards)
        {
            GameObject spawnpoint;

            if (i >= 6)
            {
                Debug.LogWarning("Not enough spawn points for all the cards.");
                break; 
            }

            if (i < 3)
            {
                spawnpoint = _TablePlayerLocations[i];
                card.transform.position = spawnpoint.transform.position;

                var cardscript = card.GetComponent<CardInstance>();

                cardscript.UpdateOrgPos(spawnpoint.transform.position);

            }
            else if (i < 6) 
            {
               // Debug.Log("above 3 thing");
                spawnpoint = _TablePlayerLocations[i-3];

                Vector3 newPos = spawnpoint.transform.position;

                float yOffset = 0.1f * 1;

                newPos.y += yOffset;

                card.transform.position = newPos;

               var cardscript = card.GetComponent<CardInstance>();

                cardscript.UpdateOrgPos(newPos); 

                // Debug.Log($"Placing {currentCardInstance.name} at spawn point {spawnpoint.transform.position}");
            }
            i++;
        }
    }

    [Button]
    public void MakeVisibleCardsInteractable()
    {
        foreach (var card in cards)
        {
            //make the cards with the tag swap be interactable
            if (card.CompareTag("Swap"))
            {
                card.TagForCanBePickedUp(true);
                Debug.Log("all cards with tag swap can nog be interacted with");
            }
        }
    }

    [Button]
    public void MakeInvisibleCardsInteractable()
    {
        foreach(var card in cards)
        {
            if (card.CompareTag("NonInteractable"))
            {
                card.TagForCanBePickedUp(true);
                Debug.Log("all cards with tag NonInteractable can nog be interacted with");
            }
        }
    }

    [Button]
   public void NoMoreCardInHand()
    {
        EveryCard.instance.cards.Clear();
        PlayerHand.instance.cards.Clear();
        EveryCard.instance.HowManyCardsLeft();
    }
}
