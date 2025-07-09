using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.GPUSort;

public class ButtonInteractable : MonoBehaviour
{
    private Button _Button;

    private void Awake()
    {
        _Button = GetComponent<Button>();
        _Button.interactable = false;
    }

    public void SetInteractable(bool canInteract)
    {
        _Button.interactable = canInteract;
        Debug.LogWarning($"Button interact set to {canInteract}");
    }

    public void ChangeClickActionToGetDropzonePile()
    {
        // Remove all existing click listeners
        _Button.onClick.RemoveAllListeners();

        // Add the new one
        _Button.onClick.AddListener(Dropzone.Instance.GetDropZonePile);

    }

    public void ChangeClickActionToGetCard()
    {
        // Remove all existing click listeners
        _Button.onClick.RemoveAllListeners();

        // Add the new one
        _Button.onClick.AddListener(EveryCard.instance.GetCard);
    }
}

