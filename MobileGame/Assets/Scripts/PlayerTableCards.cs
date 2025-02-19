using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTableCards : CardPile 
{
    public static PlayerTableCards instance;

    [SerializeField] List<GameObject> _TablePlayerLocations; 

    public override void AddCard(Card cardToAdd)
    {
        cards.Add(cardToAdd);
        Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to PlayerTABLEcards");

        if (cards.Count <=3)
        {
           // GetCardInstanceUpsideDown(cardToAdd);
            Debug.Log("getting upside down card");
        }
        else
        {
            GetCardInstance(cardToAdd);
            Debug.Log("getting NORMAL card");
        }
    }

    public override void RemoveCard(Card cardToRemove)
    {
        cards.Remove(cardToRemove);
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
