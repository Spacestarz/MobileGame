using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnLocationsPlayer : MonoBehaviour
{
    public List<GameObject> threeSpawningCardLocation;
    public List <GameObject> dropZoneLocation;
    private PlayerHand playerHand;
    private CardUIHandler cardUIHandler;//testing



    public Vector3 _A;
    public Vector3 _B;


    private void Awake()
    {
        playerHand = GetComponent<PlayerHand>();
        playerHand.playerHandChanged -= OnPlayerHandChanged;
        playerHand.playerHandChanged += OnPlayerHandChanged;

        cardUIHandler = GetComponent<CardUIHandler>();//testing

    }


    private void Start()
    {
       

       
    }

    public void OnPlayerHandChanged(PlayerHand hand)
    {
        //Debug.Log("this is onplayerhandchanged thing");
        //TODO
        //do a math formel for the cards thing check on github!

        int cardCount = hand._PlayercardsList.Count;

        if (cardCount == 0)
        {
            Debug.Log("cardcount is 0 returning");
            return;
        }
        //Debug.Log($"player got {cardCount} cards in hand ");
        //update hand visuals // move cards or something
        //check math formel to where to spawn cards? 


        //testing math for card thing
        Vector3 direction = (_B - _A).normalized;
        float totalDistance = Vector3.Distance(_A, _B);
        float step = totalDistance / (cardCount + 1);

        for (int i = 1; i <= cardCount; i++)
        {
            Vector3 position = _A + direction * step * i;
            cardUIHandler._cardInstance.transform.position = position;
        }


        #region oldcode
        //this makes so the card check if it can go to a playerhandpos will change this to a math formel
        //for (int i = 0; i < cardCount; i++)
        //{
        //    if (i < spawningPlacePlayer.Length)
        //    {
        //        GameObject spawnPoint = spawningPlacePlayer[i];
        //        cardUIHandler._cardInstance.transform.position = spawnPoint.transform.position; //testing

        //        Debug.Log("going to my playerhandpos hihi");
        //        //hand[i].position = spawningPlacePlayer[i];
        //    }
        //}
        #endregion
    }

    #region comments
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
    #endregion
}
