//using System.Collections.Generic;
//using UnityEngine;
//using TMPro;
//using System;

//public class PlayerHandOLDSCRIPT : MonoBehaviour
//{
//    public List<CardOldScript> _PlayercardsList;
//    public TextMeshProUGUI playerHandCountText;
//    private CardOldScript card;
//    private DropZoneOLDSCRIPT dropZone;
//    private GameObject dropzoneObject;

//    public Action<PlayerHandOLDSCRIPT> playerHandChanged;

//    private void Awake()
//    {
//        _PlayercardsList = new List<CardOldScript>();
//    }

//    void Start()
//    {
      
//       dropzoneObject = GameObject.Find("dropzone location");
//        if (dropzoneObject == null )
//        {
//            Debug.Log("where drop zone object");
//        }
//        dropZone = dropzoneObject.GetComponent<DropZoneOLDSCRIPT>();
//        if (dropZone == null )
//        {
//            Debug.Log("where dropzone script");
//        }
      
//    }

//    void Update()
//    {
//        if (Input.GetKeyDown(KeyCode.Q))
//        {
//           CheckPlayerHand();
//        }

      
//        if (_PlayercardsList.Count > 0)
//        {
//            playerHandCountText.text = _PlayercardsList.Count.ToString() + "cards in your hand";
//        }
//        else
//        {
//            playerHandCountText.text = ("You got no cards in hand");
//        }     
//    }

//    private void CheckPlayerHand()
//    {
//        if (_PlayercardsList.Count <1)
//        {
//            Debug.Log("You dont have any cards in hand");
//        }
//        else
//        {
//            Debug.Log($"You got {_PlayercardsList.Count} cards in your hand");

//            foreach (var card in _PlayercardsList)
//            {
//                Debug.Log($"You got {card._suit} with rank {card._rank}");
//            }
//        }
//    }

//    public void DistributeCard(CardOldScript card)
//    {
//        _PlayercardsList.Add(card);
//        playerHandChanged?.Invoke(this);
//        if (playerHandChanged == null)
//        {
//            Debug.Log("i am lost");
//        }
//       // Debug.Log($"this is card {card._suit} and {card._rank}");
//    }
//}
