using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum ItemID
{
    Money = 0,
}


[System.Serializable]
public class Item
{
    [SerializeField] private string name;

    public ItemID _id;

    public int number;

    public Item(ItemID id, int num)
    {
        _id = id;
        number = num;
    }
}
public class CharactersInfo : MonoBehaviour
{
    private static Item[] inventory;
    private int maxHealth = 5;
    public int health = 5;

    [SerializeField] private Transform heartPrefab;
    [SerializeField] private Transform heartParent;
    private List<GameObject> heartObj = new List<GameObject>();


    private GameManager manager;
    [SerializeField] private TextMeshProUGUI moneyTxt;

    private void Start()
    {
        manager = GameManager.GetInstance();

        // Initialiser l'inventaire avec un nombre d'items approprié
        inventory = new Item[System.Enum.GetValues(typeof(ItemID)).Length];

        // Initialiser chaque item dans l'inventaire
        for (int i = 0; i < inventory.Length; i++)
        {
            // Utiliser le constructeur en passant les arguments nécessaires
            inventory[i] = new Item((ItemID)i, 0); // Initialise avec 0 pour la quantité
        }

        InitHealth();
    }

    private void Update()
    {
        moneyTxt.text = " : " + inventory[((int)ItemID.Money)].number;
    }

    private void InitHealth()
    {
        health = maxHealth;

        for (int i = 0; i < maxHealth; i++)
        {
            Transform curHeart = Instantiate(heartPrefab);
            curHeart.SetParent(heartParent);
            heartObj.Add(curHeart.gameObject);
        }
    }

    private void TakeDamage(int _damage)
    {
        health -= _damage;
        //ReAffiche les coeurs
        for (int i = 0; i < maxHealth; i++)
        {
            bool _state = i > health ? true : false;  

            heartObj[i].SetActive(_state);
        }
    }

    public static void AddItem(ItemID _id, int _number)
    {
        inventory[((int)_id)].number += _number;
    }
}