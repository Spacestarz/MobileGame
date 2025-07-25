//using System;
//using System.Collections.Generic;
//using UnityEngine;

//public class distributeCardsOLDSCRIPT : MonoBehaviour
//{
//    private CardManagerOLDSCRIPT cardManager;
//    private PlayerHandOLDSCRIPT playerHand;
//    private CardUIHandlerOLDSCRIPT cardUIHandler;
//    private SpawnLocationsPlayerOLDSCRIPT SpawnLocationsScript;

//    private List<GameObject> _beginnerSpawn;

//    public GameObject backgroundPreFab;

//    void Start()
//    {

//        cardManager = GetComponent<CardManagerOLDSCRIPT>();
//        playerHand = GetComponent<PlayerHandOLDSCRIPT>();
//        cardUIHandler = GetComponent<CardUIHandlerOLDSCRIPT>();
//        SpawnLocationsScript = GetComponent<SpawnLocationsPlayerOLDSCRIPT>();

//        _beginnerSpawn = SpawnLocationsScript.threeSpawningCardLocation;
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.R))
//        {
//            if (cardManager.allCardsList.Count > 0)
//            {
//                int randomIndex = UnityEngine.Random.Range(0, cardManager.allCardsList.Count);
//                Distribute(randomIndex);
//            }
//        }
//    }

//    public void GetStartCards()
//    {
//        //3 card go to table upside down
//        //3 cards go on the upside down cards
//        //3 cards go to player hand

//        for (int i = 0; i < 3; i++) //instantiate the 3 upside down cards
//        {
//            CardOldScript card = cardManager.allCardsList[0]; //get the cards top in list
//            GameObject spawnpoint = _beginnerSpawn[i];
//            Instantiate(backgroundPreFab, spawnpoint.transform.position, spawnpoint.transform.rotation);
//            cardManager.allCardsList.Remove(card);
//            Debug.Log($"removing {card._rank} {card._suit}  from allcards list. They are upside down");
//        }

//        for (int i = 0; i < 3; i++) //instantiate 3 cards above the upside down cards
//        {
//            CardOldScript card = cardManager.allCardsList[0]; //get the cards top in list
//            cardManager.allCardsList.Remove(card);//removing card from allcardslist
//            GameObject spawnpoint = _beginnerSpawn[i];

//            //gets the visuals for the card.
//            cardUIHandler.GetCardUI(card._rank, card._suit); //getting the suit and rank
//            cardUIHandler._cardInstance.transform.position = spawnpoint.transform.position; //changes the position

//            //Debug.Log($"I should be visible {cardUIHandler._cardInstance}");
//        }

//        for (int i = 0; i < 3; i++) //instantiate 3 cards for the players hand
//        {
//            CardOldScript card = cardManager.allCardsList[0]; //get the cards top in list
//           // Debug.Log("instantiate cards" + card.ToString());
//            //cardManager.allCardsList.Remove(card);//removing card from allcardslist
//           // cardUIHandler.GetCardUI(card._rank, card._suit);//getting the suit and rank
//            //playerHand._PlayercardsList.Add(card); //adding card to playerhandList
//            Distribute(0);

//            //playerHand.playerHandChanged?.Invoke(this);
//            // GameObject spawnpoint = SpawnLocationsScript.spawningPlacePlayer[i];

//            //gets the visuals for the card.

//            // cardUIHandler._cardInstance.transform.position = spawnpoint.transform.position; //changes the position
//        }

//    }

//    public void Distribute(int index)
//    {
//        if ( index >= 0 && index < cardManager.allCardsList.Count) //ensure index is valid
//        {
//            CardOldScript card = cardManager.allCardsList[index];
//           // Debug.Log($"Retrieving card. Suit: {card._suit} Rank: {card._rank}");

//            //gets the visuals for the card.
//            cardUIHandler.GetCardUI(card._rank, card._suit); //sending the suit and rank

//            cardManager.allCardsList.Remove(card);
//            //Debug.Log($"Removing suit {card._suit} rank: {card._rank}");

//            playerHand.DistributeCard(card); //distribute card to player hand class
//            //playerHand.PlayercardsList.Add(card); //player gets a card
//            //Debug.Log($"Player got suit {card._suit} rank: {card._rank}");

//            // cardManager.DiscardList.Add(card);
//            //Debug.Log($"Adding suit {card._suit} rank: {card._rank}");
//        }
       
//    }
//}
