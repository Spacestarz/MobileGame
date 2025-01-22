using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnLocationsPlayer : MonoBehaviour
{
    public GameObject[] spawningPlacePlayer; //change to list later :) generally better and more comftable with list
    private PlayerHand playerHand;
    private CardUIHandler cardUIHandler;//testing

    private void Start()
    {
        playerHand = GetComponent<PlayerHand>();
        playerHand.playerHandChanged += OnPlayerHandChanged;
        cardUIHandler = GetComponent<CardUIHandler>();//testing

    }

    private void OnPlayerHandChanged(PlayerHand hand)
    {
        int cardCount = playerHand._PlayercardsList.Count;
        Debug.Log($"player got {cardCount} cards in hand "); //it says player got 1 card so why wont it go to the right position?
        //update hand visuals // move cards or something
        //check math formel to where to spawn cards? 
        for (int i = 0; i < cardCount; i++)
        {
            if (i < spawningPlacePlayer.Length)
            {
                GameObject spawnPoint = spawningPlacePlayer[i];
                cardUIHandler._cardInstance.transform.position = spawnPoint.transform.position; //testing

                Debug.Log("going to my playerhandpos hihi");
                //hand[i].position = spawningPlacePlayer[i];
            }
        }
    }

    public void PlayerCardLocations()
    { 
        var spawnPosition = spawningPlacePlayer.Length;
        Debug.Log("location thing");
    }


    
   

    /*

    bit code from teacher to help with the spawnpoints and handupdate (observer)

    private void Start()
    {
     //   CardUIHandler.HandUpdated += OnHandUpdated
    }

    public List<Card> PlayerHand = new(); //take the playerhand list here i think

    private void OnHandUpdated(List<Card> playerHand) //the playerhandlist?
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            if (i < spawningPlacePlayer.Length)
            {
                //playerHand[i].position = spawningPlacePlayer[i]
            }
        }
    } 

    */
}
