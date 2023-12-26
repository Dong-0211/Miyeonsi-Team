using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public AbilityManager data;

    private static GameManager instance;

    private void Awake()
    {
        data = Resources.Load<AbilityManager>("ScriptableObject/Ability");

        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    public static GameManager Instance
    {
        get
        {
            if(instance == null) return null;
            return instance;
        }
    }

    public void InitGame()
    {
        
    }
}
