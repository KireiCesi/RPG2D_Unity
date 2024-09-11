using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharactersInfo : MonoBehaviour
{
    public int moneyCount = 0;
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

        InitHealth();
    }

    private void Update()
    {
        moneyTxt.text = " : " + moneyCount;
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
            if (i > health)
            {
                heartObj[i].SetActive(true);
            }
            else
            {
                heartObj[i].SetActive(false);
            }
            
        }
    }
}