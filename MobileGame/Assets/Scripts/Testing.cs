using UnityEngine;
using NaughtyAttributes;
using static UnityEngine.ParticleSystem;
using System.Collections;

public class Testing : MonoBehaviour
{
    public static Testing instance;
 

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


    [Button]
    private void TestingTakingAChance()
    {
        Dropzone.Instance._IsTakingAChance = true;
        Dropzone.Instance._OnChangedChanceBool?.Invoke();
    }

}
