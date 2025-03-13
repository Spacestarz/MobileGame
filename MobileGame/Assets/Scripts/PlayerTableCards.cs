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
       
       // Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to PlayerTABLEcards");

        if (cards.Count <=3)
        {
            //changing parent and name for better visability in inspector 
            cardToAdd.gameObject.name = "TableCardPlayerUpsideDown";
            GameObject parentObject = GameObject.Find("PlayersCardTableFolder");
            cardToAdd.gameObject.transform.SetParent(parentObject.transform, false);
            // GetCardInstanceUpsideDown(cardToAdd);
            Debug.Log("getting upside down card");
        }
        else
        {
            // change the card layeroption so it gets aboeve the upside down cards

            //changing parent and name for better visability in inspector 
            cardToAdd.gameObject.name = "TableCardPlayerVisible";
            GameObject parentObject = GameObject.Find("PlayersCardTableFolder");
            cardToAdd.gameObject.transform.SetParent(parentObject.transform, false);

          

            GetCardInstance(cardToAdd);
            cardToAdd.FlipCard(); //3 should now be up
            Debug.Log("3 should be able to be visible");
           // Debug.Log("getting NORMAL card");
        }
    }

    public override void RemoveCard(Card cardToRemove)
    {
        base.RemoveCard(cardToRemove);
        Debug.Log($"Removing {cardToRemove._suit}  with rank  {cardToRemove._rank}  from PlayerTableCard");
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

    private void UpdateTable() // need to fix this
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
            }
            else if (i < 6) 
            {
               // Debug.Log("above 3 thing");
                spawnpoint = _TablePlayerLocations[i-3];

                Vector3 newPos = spawnpoint.transform.position;

                float yOffset = 0.1f * 1;

                newPos.y += yOffset;

                card.transform.position = newPos;

               // Debug.Log($"Placing {currentCardInstance.name} at spawn point {spawnpoint.transform.position}");
            }
            i++;
        }
    }

    //public void GetCardInstanceUpsideDown(Card card)
    //{
    //    var CardInstanceThing = MakeCards.Instance.MakeUpsideDownCard(card);
    //    UpdateTable();
    //}

}
