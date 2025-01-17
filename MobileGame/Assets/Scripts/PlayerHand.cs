using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHand : MonoBehaviour
{
    public List<Card> PlayercardsList;
    public TextMeshProUGUI playerHandCountText;
    private Card card;

    void Start()
    {
        PlayercardsList = new List<Card>();
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
    }

    private void CheckPlayerHand()
    {
        if (PlayercardsList.Count <1)
        {
            Debug.Log("You dont have any cards in hand");
        }
        else
        {
            Debug.Log($"You got {PlayercardsList.Count}  cards in your hand");

            foreach (var card in PlayercardsList)
            {
                Debug.Log($"You got {card._suit} with rank {card._rank}");
            }
        }

        

    }
}
