using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.GPUSort;

public class OpponentDialog : MonoBehaviour
{
    public static OpponentDialog Instance;

    public string _DialogText = "";
    [SerializeField] private GameObject _DialogObject;
    [SerializeField] private TextMeshProUGUI _TmproText;

    private float _delay = 5f;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        _DialogObject.SetActive(false);
    }

    public void ActivateDialog(string Dialog)
    {
        _DialogObject.SetActive(true);
        _TmproText.text = Dialog;
        StartCoroutine(HideAiDialog(_delay));
    }

    private IEnumerator HideAiDialog(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _DialogObject.SetActive(false);
    }


}
