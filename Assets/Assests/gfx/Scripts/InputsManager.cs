using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class InputsManager : MonoBehaviour
{
    public static InputsManager instance { private set; get; }

    private InputAction moveAction;

    private PlayerInput inputs;

    [HideInInspector] public UnityEvent interactionEvent; 

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // Détruire le GameObject en double
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Garde le GameObject à travers les scènes

            inputs = GetComponent<PlayerInput>();

            moveAction = inputs.actions.FindAction("Move");
        }
    }

    public Vector2 GetMovingInputs()
    {
        return moveAction.ReadValue<Vector2>();
    }

    public void OnInteract()
    {
        interactionEvent.Invoke();
    }
}
