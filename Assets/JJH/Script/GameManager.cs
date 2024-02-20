using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TimeNotation
{
    Am,
    Pm,
    Night
}

public class GameManager : MonoBehaviour
{
    public AbilityManager data;
    
    private static GameManager instance;

    [SerializeField] TimeNotation currentTime = TimeNotation.Am;

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

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return))
        {
            NextTime();
        }
    }

    public void InitGame()
    {
        
    }

    public void NextTime()
    {
        if (currentTime == TimeNotation.Am)
        {
            currentTime = TimeNotation.Pm;
        }
        else if (currentTime == TimeNotation.Pm)
        {
            currentTime = TimeNotation.Night;
        }
        else if(currentTime == TimeNotation.Night)
        {
            currentTime = TimeNotation.Am;
            data.abilities.DateCalculation();
            StockManager.Instance.stock.upDate += 1;
            //GameManager.Instance.stock.upDate += 1;
        }
    }
}
