using UnityEngine;
using System.Collections.Generic;

public class OpponentTableCard : CardPile
{
    public static OpponentTableCard Instance;

    [SerializeField] List<GameObject> _TableOpponentLocations;

    public override void AddCard(Card cardToAdd)
    {
        base.AddCard(cardToAdd);
        var cardinstancescript = cardToAdd.GetComponent<CardInstance>();
        cardinstancescript.SetTextVisability(false);
        UpdateTable();
       // Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to TableOpponentCards");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        base.RemoveCard(cardToRemove);
       // Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from TableOpponentCards");
    }

    private void Awake()
    {
        //Debug.Log("opponentTABLEcards here");
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        cards = new List<Card>();
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
                spawnpoint = _TableOpponentLocations[i];
                card.transform.position = spawnpoint.transform.position;
            }
            else if (i < 6)
            {
                // Debug.Log("above 3 thing");
                spawnpoint = _TableOpponentLocations[i - 3];

                Vector3 newPos = spawnpoint.transform.position;

                float yOffset = 0.1f * 1;

                newPos.y += yOffset;

                card.transform.position = newPos;

                // Debug.Log($"Placing {currentCardInstance.name} at spawn point {spawnpoint.transform.position}");
            }
            i++;
        }

    }
}
