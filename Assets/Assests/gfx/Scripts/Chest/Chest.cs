using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] graphism;
    [SerializeField] private Sprite[] openSprite;
    [SerializeField] private Sprite[] closeSprite;

    private GameManager manager;
    private InputAction interactAction;

    private bool isReach = false;

    private void Start()
    {
        manager = GameManager.GetInstance();
        interactAction = manager.GetInputs().actions.FindAction("Interact");
    }

    private void Update()
    {
        float _interact = interactAction.ReadValue<float>();

        if (isReach && _interact > 0)
        {
            Open();
        }
        else if (!isReach)
        {
            Close();
        }
    }

    private void Open()
    {
        for (int i = 0; i < graphism.Length; i++) 
        {
            graphism[i].sprite = openSprite[i];
        }
    }

    private void Close()
    {
        for (int i = 0; i < graphism.Length; i++) 
        {
            graphism[i].sprite = closeSprite[i];
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isReach = false;
        }
    }
}
