using UnityEngine;

public class CardObjectPool : MonoBehaviour
{
    //objects in the pool
    public GameObject _heartPrefab;
    public GameObject _cloverPrefab;
    public GameObject _spadePrefab;
    public GameObject _diamondPrefab;

    //the max amount
    [SerializeField] int maxAmount = 52;

    //have list with cards from where we can pull the cards from

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDisable() //clear list when done
    {
        
    }

    public void DestroyCard()
    {

    }
}
