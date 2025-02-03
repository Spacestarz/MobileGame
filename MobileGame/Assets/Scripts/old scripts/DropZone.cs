using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class DropZone : MonoBehaviour
{
    public List <Card> _dropzoneCardList;
    private Card card;
    //public TextMeshProUGUI _dropZoneText;
    private GameObject _cardmanagerObject;
    private CardManager _cardManagerScript;
    private PlayerHand _playerhand;
    private SpawnLocationsPlayer _spawnLocation;
    private TouchandMouseInputs _touchandMouseInputs;
    public CardUIHandler _CardUIHandler;

    public GameObject _dropZoneLocationOfCards;

    private float stackOffSet = 0.05f; //testing for effect 
    private GameObject _latestCardInZone;

    private GameObject _previouscard;
    
    

    void Start()
    {
        
         _touchandMouseInputs = Object.FindFirstObjectByType<TouchandMouseInputs>();
        _cardmanagerObject = GameObject.Find("CardManager");
        _cardManagerScript = _cardmanagerObject.GetComponent<CardManager>();
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

    public void PutCardInDropZone(Card carddata, GameObject CardGameObject) 
        //pretty sure i feck up something here make sure gameobject/visuals follow!
    {
        Card card = carddata;

      if (_dropzoneCardList.Count > 0)
      {
            Debug.Log("will compare to dropzone");
            CanCardBePlaced(card, CardGameObject); //will check here if the card can be placed
      }
      else
      {
            Vector3 dropzonelocation = _dropZoneLocationOfCards.transform.position;

            _dropzoneCardList.Add(card);
            _playerhand._PlayercardsList.Remove(card);

            dropzonelocation.z = _dropzoneCardList.Count * stackOffSet;

            //_touchandMouseInputs._clickedCard.transform.position = _dropZoneLocationOfCards.transform.position;
            CardGameObject.transform.position = _dropZoneLocationOfCards.transform.position;
            Debug.Log("testing");

            // _touchandMouseInputs._clickedCard.GetComponent<HoverOverCard>().enabled = false; //turn off hover script
            var hoveroverDisable = CardGameObject.GetComponent<HoverOverCard>();
            hoveroverDisable.enabled = false;
            Destroy(hoveroverDisable);
            Debug.Log("DEFSTROY");
            _touchandMouseInputs.FollowMouse = false;
            _touchandMouseInputs._clickedCard = null;

            Debug.Log($"no card in dropzone adding {card._suit} with rank {card._rank}");
      }
        // dropZone.dropzoneCardList.Add(card); //only add if you can place the card there
        
    }

    public void CanCardBePlaced(Card CardData, GameObject CardObject)
    {
        Card FirstcardDropZone = _dropzoneCardList [0];
      //  Debug.Log($"rank and suit of playercard {CardData._suit} and rank {CardData._rank} ");

        if (CardData._rank > FirstcardDropZone._rank)
        {
            if (_previouscard != null )
            {
                CheckTextComp(_previouscard);
                Debug.Log("this is the previous caard" + _previouscard.name);
            }

            //updates previous card
            _previouscard = CardObject;

            Vector3 dropzonelocation = _dropZoneLocationOfCards.transform.position;

            Debug.Log("You can play this card");
            _dropzoneCardList.Add (CardData);
            dropzonelocation.z = _dropzoneCardList.Count * stackOffSet;

            _touchandMouseInputs._clickedCard.transform.position = _dropZoneLocationOfCards.transform.position;

            _touchandMouseInputs._clickedCard.GetComponent<HoverOverCard>().enabled = false; //turn off hover script

            _touchandMouseInputs.FollowMouse = false;

            _touchandMouseInputs._clickedCard = null;
            Debug.Log($"adding your card {CardData._suit} with rank {CardData._rank} to dropzone");
            _playerhand._PlayercardsList.Remove (CardData);


            if (CardData._rank == 10)
            {
                Debug.Log("Player played a 10. Everything to discard pile");
                
                for (global::System.Int32 i = _dropzoneCardList.Count - 1; i>=0; i--)
                {
                    _dropzoneCardList.Remove(_dropzoneCardList[i]);
                    _cardManagerScript.DiscardList.Add(_dropzoneCardList[i]);
                    Debug.Log($"adding {_dropzoneCardList[i]} to discardlist");
                }
            }
            else
            {
                Debug.Log("Not a 10, checking if 4 in a row");
                CheckIf4Row();
            }

            // CheckTextComp(FirstcardDropZone.);

            //here i change the card I HOLD IN HAND DAFUQ STAHP.

        }
        else
        {
            Debug.Log("You cant place this card. Go back to orgcardpos");
            _touchandMouseInputs._clickedCard.transform.position = _touchandMouseInputs._OrgPosFromHoverScript;
            _touchandMouseInputs.FollowMouse =false;
            _touchandMouseInputs._clickedCard = null;
        }

    }

    public void CheckTextComp(GameObject card)
    {
        TextMeshPro[] textMeshProComponents = card.GetComponentsInChildren<TextMeshPro>();

        if (textMeshProComponents.Length > 0)
        {
            foreach (TextMeshPro textMeshPro in textMeshProComponents)
            {
                textMeshPro.enabled = false; // Disabling the text
                Debug.Log("TextMeshPro component disabled.");
            }
        }
        else
        {
            Debug.Log("No TextMeshPro components found in the children of the last card.");
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
