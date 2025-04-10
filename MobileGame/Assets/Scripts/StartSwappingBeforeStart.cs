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


    public void SwapCards (Card HandCard, Card TableCard)
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

        //removing card from their original lists
        PlayerHand.instance.RemoveCard(HandCard);
        PlayerTableCards.instance.RemoveCard(TableCard);

        Debug.Log($"HandCardIndex is {handCardIndex}");
        Debug.Log($"TableCardIndex is {tableCardIndex}");

        if (tableCardIndex < 0 || tableCardIndex > PlayerHand.instance.cards.Count)
        {
            Debug.LogError($"Invalid tableCardIndex: {tableCardIndex}");
            return;
        }

        if (handCardIndex < 0 || handCardIndex > PlayerTableCards.instance.cards.Count)
        {
            Debug.LogError($"Invalid handCardIndex: {handCardIndex}");
            return;
        }



        //adding the cards to their swap lists with their correct new index in list
        PlayerHand.instance.cards.Insert(tableCardIndex, HandCard);
        PlayerTableCards.instance.cards.Insert(handCardIndex, TableCard);

        PlayerHand.instance.UpdateHand();
        PlayerTableCards.instance.UpdateTable();


        // Validation (optional)
        Debug.Log(PlayerTableCards.instance.cards.Contains(HandCard)
            ? "HandCard successfully swapped to TableCards list."
            : "HandCard not in TableCards list.");

        Debug.Log(PlayerHand.instance.cards.Contains(TableCard)
            ? "TableCard successfully swapped to HandCards list."
            : "TableCard not in HandCards list.");


        tableCardScript.GoBackOrgPos();
        handCardScript.GoBackOrgPos();

    }

    public void EndSwapping ()
    {
        TurnOffSwapStage();
        TurnOnGameStage();
        Debug.Log($"swappingphase is; {_SwappingPhase}");
    }
}
