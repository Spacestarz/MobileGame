using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class DropZone : MonoBehaviour
{
    public List <Card> _dropzoneCardList;
    private Card card;
    public TextMeshProUGUI _dropZoneText;
    private GameObject _cardmanagerObject;
    private PlayerHand _playerhand;

    void Start()
    {
        _cardmanagerObject = GameObject.Find("CardManager");
        _playerhand = _cardmanagerObject.GetComponent<PlayerHand>();

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
            _dropZoneText.text = _dropzoneCardList.Count.ToString() +  "" + $"card in the dropZone pile"  + $" \n" + $"The card at the top is {card._suit} with rank {card._rank} " ;
        }
        else
        {
            _dropZoneText.text = ("No cards are in the dropzone");
        }
    }

    public void CanCardBePlaced(Card playercard)
    {
        Card FirstcardDropZone = _dropzoneCardList [0];

        Debug.Log($"rank and suit of playercard {playercard._suit} and rank {playercard._rank} ");
        if (playercard._rank > FirstcardDropZone._rank)
        {
            Debug.Log("You can play this card");
            _dropzoneCardList.Add (playercard);
            Debug.Log($"adding your card {playercard._suit} with rank {playercard._rank} to dropzone");
            _playerhand.PlayercardsList.Remove (playercard);

            if (playercard._rank == 10)
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
