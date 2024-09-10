using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactersInfo : MonoBehaviour
{
    public int moneyCount = 0;

    private GameManager manager;

    private void Start()
    {
        manager = GameManager.GetInstance();        
    }
}