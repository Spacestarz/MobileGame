using NaughtyAttributes;
using System;
using TMPro;
using UnityEngine;

public class StartSwappingBeforeStart : MonoBehaviour
{
    public static StartSwappingBeforeStart instance;

    [SerializeField] private GameObject _GameStage;
    [SerializeField] private GameObject _SwappingStage;

    public bool _SwappingPhase = true;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {

    }

    public void TurnOnSwapStage()
    {
        ActivateChildren(_SwappingStage, true);
        _SwappingPhase = true;
    }

    
    public void TurnOffSwapStage()
    {
        ActivateChildren(_SwappingStage, false);
        _SwappingPhase = false;
        TrackingTurns.Instance.SwappPhaseOver();
    }

    
    public void TurnOnGameStage()
    {
        ActivateChildren(_GameStage, true);
        PlayerTableCards.instance.HideTableCards();
    }


    
    public void TurnOffGameStage()
    {
        ActivateChildren(_GameStage, false);
    }


    public void ActivateChildren (GameObject parent, bool activate)
    {
        foreach (Transform child in parent.transform)
        {
            child.gameObject.SetActive(activate);
        }
    }


    public void SwapCards(Card HandCard, Card TableCard)
    {

        //gets the orgpositions of the cards
        var handCardScript = HandCard.GetComponent<CardInstance>();
        var tableCardScript = TableCard.GetComponent<CardInstance>();

        //get index of handcard
        int handCardIndex = PlayerHand.instance.cards.FindIndex(Card => Card.GetInstanceID() == HandCard.GetInstanceID());

        int tableCardIndex = PlayerTableCards.instance.cards.FindIndex(Card => Card.GetInstanceID() == TableCard.GetInstanceID());

        if (handCardIndex == -1 || tableCardIndex == -1)
        {
            Debug.LogError("One or both cards were not found in their respective lists.");
            return;
        }

        Debug.Log($"HandCardIndex: {handCardIndex}, TableCardIndex: {tableCardIndex}");

        //remove the cards from their original lists
        PlayerHand.instance.RemoveCard(HandCard);
        PlayerTableCards.instance.RemoveCard(TableCard);

        //add the cards to the other list
        PlayerTableCards.instance.AddCard(HandCard);
        PlayerHand.instance.AddCard(TableCard);

        // Handcard to Playertabl
        if (PlayerTableCards.instance.cards.Contains(HandCard))
        {
            //LOOK INTO THIS LOGIC MORE SAM DO IT NEXT TIME

            
            PlayerTableCards.instance.cards.Remove(HandCard);
            // Insert at the correct index
            PlayerTableCards.instance.cards.Insert(tableCardIndex, HandCard); 
        }

        // Tablecard to Playerhand
        if (PlayerHand.instance.cards.Contains(TableCard))
        {
            PlayerHand.instance.cards.Remove(TableCard);  
            // Insert at the correct index
            PlayerHand.instance.cards.Insert(handCardIndex, TableCard);  
        }

        PlayerHand.instance.UpdateHand();
        Debug.Log("update hand");

        PlayerTableCards.instance.UpdateTable();

        //checking if they are in the right list

        if (PlayerTableCards.instance.cards.Contains(HandCard))
        {
            Debug.Log("HandCard is in TableCards list");
        }
        else
        {
            Debug.Log("HandCard is NOT in TableCards list");
        }

        if (PlayerHand.instance.cards.Contains(TableCard))
        {
            Debug.Log("TableCard is in HandCards list");
        }
        else
        {
            Debug.Log("TableCard is NOT in HandCards list");
        }

    }

    public void EndSwapping ()
    {
        TurnOffSwapStage();
        TurnOnGameStage();
        Debug.Log($"swappingphase is; {_SwappingPhase}");
    }
}
