using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.Jobs;
using Unity.VisualScripting;
using UnityEngine;
using NaughtyAttributes;

public class Dropzone : CardPile
{
    public static Dropzone Instance;
    public List<Card> _dropZoneList;

    private Card FirstInStackCard;

    public override void AddCard(Card cardToAdd)
    {
        _dropZoneList.Add(cardToAdd);
        Debug.Log($"Adding {cardToAdd._suit} with rank {cardToAdd._rank} to Dropzone");
    }

    public override void RemoveCard(Card cardToRemove)
    {
        _dropZoneList.Remove(cardToRemove);
        Debug.Log($"Removing {cardToRemove._suit} with rank {cardToRemove._rank} from dropzone");
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

    [Button]
    void CanIGoInDropZone() //in here should be Card NewCard later
    {
       Card Newcard = PlayerHand.instance._PlayerHandcards[0];//testing

        if (_dropZoneList.Count > 0)
        {
            Debug.Log("i sshould not see you");
            _dropZoneList[0] = FirstInStackCard;

            if (Newcard._rank > FirstInStackCard._rank || Newcard._rank == FirstInStackCard._rank)
            {
                Debug.Log("adding but i shouldent");
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
            PlayerHand.instance.RemoveCard(Newcard);
            Debug.Log($"adding a new card to dropzone (dropzone script here... {Newcard._suit} with rank {Newcard._rank})");
        }


        if (_dropZoneList.Count >= 3) //here i will check if the all have the same rank so 4 in a row
        {
            Card SecondInStackCard;
            Card ThirdCard;
            Card FourthCard;


            //  getting the cards top 4 including the players last added card
            FirstInStackCard = _dropZoneList[_dropZoneList.Count - 1];
            SecondInStackCard = _dropZoneList[_dropZoneList.Count - 2];
            ThirdCard = _dropZoneList[_dropZoneList.Count - 3];
            FourthCard = _dropZoneList [_dropZoneList.Count - 4];
        }
        



    }
    
}
