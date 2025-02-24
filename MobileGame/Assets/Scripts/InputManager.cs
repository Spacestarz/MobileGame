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

            RaycastHit2D CheckIfDropZoneCollider = Physics2D.Raycast(mousepos, Vector2.zero, 100f, LayerMask.GetMask("dropZoneLayer"));

            //if releasing over dropzone and holding a card
            if (CheckIfDropZoneCollider.collider != null && _CardHeld)
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

            if (_CardHeld && CheckIfDropZoneCollider.collider == null)
            {
                var cardscript = _CardHeld.GetComponent<CardInstance>();
                cardscript.GoBackOrgPos();
                _CardHeld = null;
            }
            _CardHeld = null ;
        }

    }
}


      

     

        
