using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

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
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

}
