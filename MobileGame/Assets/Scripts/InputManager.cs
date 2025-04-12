using Unity.VisualScripting;
using UnityEngine;
using static TrackingTurns;

public class InputManager : MonoBehaviour
{
    //this script talks to CardVisuals script

    public static InputManager Instance;

    public bool _followMouse;

    public GameObject _CardHeld;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        if (_CardHeld == null)
        {

        }
    }
    // tryClick
    // trydrop
    // private bool TryDrop(out gameObject)
    // returnerar true om den lyckas droppa den på grejen
    // gameObject.trygetcomponent<cardPile>().AddCard(heldCard.Card) eller något
    // if false, return to pickedUp location / hand


    void Update()
    {
        //when down thing

        if (TrackingTurns.Instance.DisableInput || TrackingTurns.Instance._CurrentTurn == TurnState.OpponentTurn)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("click");
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Card") && _CardHeld == null)
            {
                Debug.Log("hit a card");
                _CardHeld = hit.collider.gameObject;
            }
            else
            {
                Debug.Log("no card here");
            }
        }

        if (_CardHeld != null)
        {
            //when holding down mouse/touch
            if (Input.GetMouseButton(0))
            {
                var cardscript = _CardHeld.GetComponent<CardInstance>();
                _followMouse = true;
            }

            if (_followMouse)
            {
                Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _CardHeld.transform.position = mousepos;
            }
        }

        //when releasing the mouse
        if (Input.GetMouseButtonUp(0))
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //check if we are over a dropzone
            RaycastHit2D CheckIfDropZoneCollider = Physics2D.Raycast(mousepos, Vector2.zero, 100f, LayerMask.GetMask("dropZoneLayer"));

            //hit is to check if we are over a card
            RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("Swap") && _CardHeld != null && StartSwappingBeforeStart.instance._SwappingPhase == true)
            {
                Debug.Log("hit a card trying to swap");
                var cardscript1 =  _CardHeld.GetComponent<CardInstance>();
                var cardscript2 = hit.collider.gameObject.GetComponent<CardInstance>();

                var card1 = cardscript1.GetCardData();
                var card2 = cardscript2.GetCardData();

                if (cardscript1 != cardscript2)
                {
                    StartSwappingBeforeStart.instance.SwapCards(card1, card2);
                }
                else
                {
                    Debug.LogWarning("same card cant swap");
                    cardscript1.GoBackOrgPos();
                    cardscript2.GoBackOrgPos();
                }

            }
            else
            {
                Debug.Log("Nope cardswap logic. Inputmanager row 111");

            }



            //if releasing over dropzone and holding a card and NOT in swapping phase
            if (CheckIfDropZoneCollider.collider != null && _CardHeld && StartSwappingBeforeStart.instance._SwappingPhase == false)
            {
                var CardinstanceScript =  _CardHeld.GetComponent<CardInstance>();
                // var cardHeldCard = CardinstanceScript.GetCardData();
                 Dropzone.Instance.PutCardInDropzone(_CardHeld.GetComponent<Card>());

            }
            else
            {
                Debug.Log("dropzone not here");
            }

            _followMouse = false;


            if (_CardHeld && CheckIfDropZoneCollider.collider == null && StartSwappingBeforeStart.instance._SwappingPhase == false)
            {
                var cardscript = _CardHeld.GetComponent<CardInstance>();
                cardscript.GoBackOrgPos();
                _CardHeld = null;
            }

            _CardHeld = null ;
        }

    }
}


      

     

        
