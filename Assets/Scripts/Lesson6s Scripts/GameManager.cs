using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void NumsChange(string check);
    public event NumsChange numsChange;

    int score = 0;
    List<GameObject> coins = new List<GameObject>();
    [SerializeField]
    GameObject[] allPaths;
    int index = 0;
    bool flag = true;

    private GameManager() { }

    private static GameManager instance;
    public static GameManager Instance {  get { return instance; } }

    public void Score(int score)
    {
        this.score += score;
        numsChange?.Invoke("forCoins");
    }

    public List<GameObject> Coins()
    {
        return coins;
    }

    public GameObject[] AllPaths()
    {
        return allPaths;
    }

    public int Index(int setIndex)
    {
        index = setIndex;
        return index;
    }
    public int Index()
    {
        return index;
    }
    
    public bool GetFlag()
    {
        return flag;
    }
    public void SetFlag(bool status)
    {
        flag = status;
    }

    float damaged = 0;
    public float getDamaged()
        { return damaged; }
    public void setDamaged(float addedDamage)
    {
        damaged = addedDamage;
        numsChange?.Invoke("forHealth");
    }

    float fuel = 100;
    public float getFuel() { return fuel; }
    public void setFuel(int minusValue)
    {
        fuel -= minusValue;
        numsChange?.Invoke("forFuel");
    }

    int laps = 0;
    public int getLaps() { return laps; }
    public void setLaps(int plusValue)
    {
        laps += plusValue;
        numsChange?.Invoke("forLaps");
    }
    private void Awake()
    {
        instance = GetComponent<GameManager>();

    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetScored()
    {
        return score;
    }
}
