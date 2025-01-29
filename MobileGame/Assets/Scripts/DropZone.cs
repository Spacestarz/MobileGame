using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class DropZone : MonoBehaviour
{
    public List <Card> _dropzoneCardList;
    private Card card;
    //public TextMeshProUGUI _dropZoneText;
    private GameObject _cardmanagerObject;
    private PlayerHand _playerhand;
    private SpawnLocationsPlayer _spawnLocation;
    
    

    void Start()
    {
        _cardmanagerObject = GameObject.Find("CardManager");
        _playerhand = _cardmanagerObject.GetComponent<PlayerHand>();
        _spawnLocation = GetComponent<SpawnLocationsPlayer>();

        _dropzoneCardList = new List<Card> ();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            DropZonePile();
        }
    }

    private void DropZonePile()
    {
        if (_dropzoneCardList.Count > 0)
        {
           Card card = _dropzoneCardList[0];
            Debug.Log("idk what to said commented out stuff lol");
            //_dropZoneText.text = _dropzoneCardList.Count.ToString() +  "" + $"card in the dropZone pile"  + $" \n" + $"The card at the top is {card._suit} with rank {card._rank} " ;
        }
        else
        {
            Debug.Log("\"No cards are in the dropzone\"");
            //_dropZoneText.text = ("No cards are in the dropzone");
        }
    }

    public void PutCardInDropZone(Card carddata)
    {
        Card card = carddata;

      if (_dropzoneCardList.Count > 0)
      {
         Debug.Log("will compare to dropzone");
        CanCardBePlaced(card); //will check here if the card can be placed
      }
      else
      {
         _dropzoneCardList.Add(card);
         _playerhand._PlayercardsList.Remove(card);
         Debug.Log($"no card in dropzone adding {card._suit} with rank {card._rank}");
      }
        // dropZone.dropzoneCardList.Add(card); //only add if you can place the card there
        
    }

    public void CanCardBePlaced(Card CardData)
    {
        
        Card FirstcardDropZone = _dropzoneCardList [0];

        Debug.Log(FirstcardDropZone+"what is this idk wtf");
        

        Debug.Log($"rank and suit of playercard {CardData._suit} and rank {CardData._rank} ");

        if (CardData._rank > FirstcardDropZone._rank)
        {
            Debug.Log("You can play this card");
            _dropzoneCardList.Add (CardData);
            Debug.Log($"adding your card {CardData._suit} with rank {CardData._rank} to dropzone");
            _playerhand._PlayercardsList.Remove (CardData);

            if (CardData._rank == 10)
            {
                Debug.Log("Player played a 10. Everything to discard pile");
            }
            else
            {
                Debug.Log("Not a 10, checking if 4 in a row");
                CheckIf4Row();
            }
        }
        else
        {
            Debug.Log("You cant place this card");
        }

    }

    public void CheckIf4Row()
    {
        if (_dropzoneCardList.Count >= 4)
        {
            Debug.Log("Checking if its 4 in a row in rank");

           //getting the cards top 4 including the players last added card
           Card FirstCardRank = _dropzoneCardList[_dropzoneCardList.Count - 1];
           Card secondCardRank = _dropzoneCardList[_dropzoneCardList.Count - 2];
           Card thirdCardRank = _dropzoneCardList[_dropzoneCardList.Count - 3];
           Card fourCardRank = _dropzoneCardList[_dropzoneCardList.Count - 4];

            if (FirstCardRank._rank == secondCardRank._rank && secondCardRank._rank 
                == thirdCardRank._rank && thirdCardRank._rank == fourCardRank._rank)
            {
                Debug.Log("4 in a row! DISCARD PIIIILE");
            }
            else
            {
                Debug.Log("Not 4 in a row in rank");
            }
        }
    }
}
