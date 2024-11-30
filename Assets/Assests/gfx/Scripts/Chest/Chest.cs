using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    private bool open = false;

    //Refs
    private GameManager manager;


    private void Start()

    {
        manager = GameManager.GetInstance();
        InputsManager.instance.interactionEvent.AddListener(Interact);
    }

    public void Interact()
    {
        if (isReach)
        {
            ChangeState(true, openSprite);
        }
        else
        {
            ChangeState(false, closedSprite);
        }
    }


    private void ChangeState(bool _state, Sprite[] _sprites)
    {
       open = _state;
       if(open) EmptyChest();

        for (int i = 0; i < graphism.Length; i++)
        {
            graphism[i].sprite = _sprites[i];
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
