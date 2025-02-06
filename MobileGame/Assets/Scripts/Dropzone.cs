using System.Collections.Generic;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;

public class Dropzone : CardPile
{
    public static Dropzone Instance;
    public List<Card> _dropZoneList;

    private Card FirstInStackCard;

    public override void AddCard(Card cardToAdd)
    {
        _dropZoneList.Add(cardToAdd);
        Debug.Log($"Adding {cardToAdd._suit} and rank {cardToAdd._rank} from Dropzone");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _dropZoneList.Remove(cardToRemove);
        Debug.Log($"Removing {cardToRemove._suit} and rank {cardToRemove._rank} from dropzone");
    }
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        _dropZoneList = new List<Card>();
    }

    void CanIGoInDropZone(Card Newcard)
    {
        if (_dropZoneList.Count > 0)
        {
            _dropZoneList[0] = FirstInStackCard;

            if (Newcard._rank > FirstInStackCard._rank)
            {
                //adding the newcard to dropzone
                AddCard(Newcard);
            }
            else
            {
                Debug.Log("You cant add this card");
                return;
            }
        }
        else
        {
            AddCard(Newcard);
            Debug.Log($"Nothing in dropzone adding {Newcard._suit} with rank {Newcard._rank} in the dropzone");
        }


        if (_dropZoneList.Count >= 3) //here i will check if the all have the same rank so 4 in a row
        {
            
        }
        



    }
    
}
