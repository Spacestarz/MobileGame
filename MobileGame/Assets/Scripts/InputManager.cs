using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    //this script talks to CardVisuals script

<<<<<<< Updated upstream
    public CardVisuals currentCardVisualScript;
=======
    public bool _followMouse;

    public GameObject _CardHeld;

    //will get the last card from the cardvisuals. So i can store the last card.

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
>>>>>>> Stashed changes

    void Start()
    {
       
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
        if (Input.GetMouseButtonDown(0)) 
        {
            Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousepos, Vector2.zero);

           if (hit.collider!= null && hit.collider.CompareTag("Card") && _CardHeld == null)
           {
<<<<<<< Updated upstream
                if (currentCardVisualScript == null)
                {
                    Debug.Log("hit a card");
                    currentCardVisualScript = hit.collider.gameObject.GetComponentInChildren<CardVisuals>();
                }
                

                if (hit.collider.gameObject.GetComponentInChildren<CardVisuals>() == null)
                {
                    Debug.Log("cant find the cardvisual script");
                }

                currentCardVisualScript._followMouse = true; 
=======
                Debug.Log("hit a card");
                _CardHeld = hit.collider.gameObject;              
>>>>>>> Stashed changes
           }
           else
            {
                Debug.Log("no card here");
            }

            if (_followMouse)
            {
                var cardscript = _CardHeld.GetComponent<CardInstance>();
                _followMouse = true ;
            }
<<<<<<< Updated upstream

            
=======
>>>>>>> Stashed changes
        }


        if (_CardHeld != null)
        {
            //when holding down mouse/touch
            Input.GetMouseButton(0);
            {
                Vector2 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

                _followMouse = true;
                _CardHeld.transform.position = mousepos;
            }
            
        }

        //when releasing the mouse
        if (Input.GetMouseButtonUp(0))
        {
           _followMouse = false;
           var cardscript = _CardHeld.GetComponent<CardInstance>();
            cardscript.GoBackOrgPos();
            _CardHeld = null;
        }

        
    }
}
