using UnityEngine;
using UnityEngine.UI;

public class ButtonInteractable : MonoBehaviour
{
    private Button _Button;

    private void Awake()
    {
        _Button = GetComponent<Button>();
        _Button.interactable = false;
    }

    private void Start()
    {
        TrackingTurns.Instance._OnCanInteractWithButton -= OnEnableAndDisableInteract;
        TrackingTurns.Instance._OnCanInteractWithButton += OnEnableAndDisableInteract;
    }

    public void OnEnableAndDisableInteract()
    {
        _Button = GetComponent<Button>();
        _Button.interactable = !_Button.interactable;
    }
}
