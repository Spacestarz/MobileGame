using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerHand : MonoBehaviour
{
    public List<Card> PlayercardsList;
    public TextMeshProUGUI playerHandCountText;
    private Card card;
    private DropZone dropZone;
    private GameObject dropzoneObject;

    public Action<PlayerHand> playerHandChanged;

    void Start()
    {
       PlayercardsList = new List<Card>();
       dropzoneObject = GameObject.Find("Drop Zone");
        if (dropzoneObject == null )
        {
            Debug.Log("where drop zone object");
        }
        dropZone = dropzoneObject.GetComponent<DropZone>();
        if (dropZone == null )
        {
            Debug.Log("where dropzone script");
        }
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
           CheckPlayerHand();
        }

      
        if (PlayercardsList.Count > 0)
        {
            playerHandCountText.text = PlayercardsList.Count.ToString() + "cards in your hand";
        }
        else
        {
            playerHandCountText.text = ("You got no cards in hand");
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (PlayercardsList.Count > 0)
            {
                PutCardInDropZone(0);
            }
            else
            {
                dropZone._dropZoneText.text = ("You cant do that. You have no cards");
            }
        }
    }

    private void CheckPlayerHand()
    {
        if (PlayercardsList.Count <1)
        {
            Debug.Log("You dont have any cards in hand");
        }
        else
        {
            Debug.Log($"You got {PlayercardsList.Count} cards in your hand");

            foreach (var card in PlayercardsList)
            {
                Debug.Log($"You got {card._suit} with rank {card._rank}");
            }
        }
    }

    private void PutCardInDropZone(int index)
    {
        Card card = PlayercardsList[index];

        if (index >= 0 && index < PlayercardsList.Count)
        {
            if (dropZone._dropzoneCardList.Count > 0)
            {
                Debug.Log("will compare to dropzone");
                dropZone.CanCardBePlaced(card); //will check here if the card can be placed
            }
            else
            {
                dropZone._dropzoneCardList.Add(card);
                PlayercardsList.Remove(card);
                Debug.Log($"no card in dropzone adding {card._suit} with rank {card._rank}");
            }
           // dropZone.dropzoneCardList.Add(card); //only add if you can place the card there
        } 
    }

    public void DistributeCard(Card card)
    {
        PlayercardsList.Add(card);
        playerHandChanged?.Invoke(this);
    }
}
