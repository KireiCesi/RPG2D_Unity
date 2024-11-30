using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);  // D�truire le GameObject en double
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Garde le GameObject � travers les sc�nes
        }
    }

    public static GameManager GetInstance()
    {
        return instance;
    }

}
