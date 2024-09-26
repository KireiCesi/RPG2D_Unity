using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Chest : MonoBehaviour
{


    //Stats
    [SerializeField] private Item[] content;

    //Renderers
    [SerializeField] private SpriteRenderer[] graphism;
    [SerializeField] private Sprite[] openSprite;
    [SerializeField] private Sprite[] closedSprite;

    //Checkers
    private bool isReach = false;

    //Refs
    private GameManager manager;

    //Inputs
    private InputAction interactAction;


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
        
        

        EmptyChest();

        for (int i = 0; i < graphism.Length; i++) 
        {
            graphism[i].sprite = openSprite[i];
        }
    }

    private void Close()
    {
        
        for (int i = 0; i < graphism.Length; i++) 
        {
            graphism[i].sprite = closedSprite[i];
        }
    }

    private void EmptyChest()
    {
        foreach (var _item in content)
        {
            CharactersInfo.AddItem(_item._id, _item.number);
            _item.number = 0;
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
