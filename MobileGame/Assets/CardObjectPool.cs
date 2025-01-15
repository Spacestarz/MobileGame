using UnityEngine;

public class CardObjectPool : MonoBehaviour
{
    //objects in the pool
    public GameObject _heartPrefab;
    public GameObject _cloverPrefab;
    public GameObject _spadePrefab;
    public GameObject _diamondPrefab;

    //the maxamount
    [SerializeField] int maxAmount = 52;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
