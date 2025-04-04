using NaughtyAttributes;
using System;
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
    }

    [Button]
    public void TurnOffSwapStage()
    {
        ActivateChildren(_SwappingStage, false);
    }

    [Button]
    public void TurnOnGameStage()
    {
        ActivateChildren(_GameStage, true);
    }


    [Button]
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
        //insert logic to swap these 2 cards
        Debug.Log("swapping cards logic here");

        //need to know where those cards are in which list playerhand or table!

        //gets the orgpositions of the cards
        var cardscript1 = HandCard.GetComponent<CardInstance>();
        var cardscript2 = TableCard.GetComponent<CardInstance>();




    }

    public void EndSwapping ()
    {
        TurnOffSwapStage();
        TurnOnGameStage();
    }
}
