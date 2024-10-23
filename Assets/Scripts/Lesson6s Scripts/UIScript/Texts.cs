using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Texts : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI scoredCoins;
    [SerializeField]
    TextMeshProUGUI posNum;
    [SerializeField]
    TextMeshProUGUI lapsCount;
    [SerializeField]
    TextMeshProUGUI showSpeed;


    private void Awake()
    {
        ChangeLaps("forLaps");
        ChangeScore("forCoins");
    }

    void Start()
    {
        GameManager.Instance.numsChange += ChangeLaps;
        GameManager.Instance.numsChange += ChangeScore;
        StartCoroutine(nowSpeed());
        posNum.text = "1";
    }

    // Update is called once per frame
    [SerializeField]
    GreenCarControl greenCarControl;

    void Update()
    {

    }
    public void ChangeScore(string forCoins)
    {
        if (forCoins == "forCoins")
        scoredCoins.text = GameManager.Instance.GetScored() + "";
    }
    public void ChangeLaps(string forLaps)
    {
        if (forLaps == "forLaps")
        lapsCount.text = $"{GameManager.Instance.getLaps()}/5";
    }
    IEnumerator nowSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            showSpeed.text = $"{greenCarControl.getSpeed()} m/s";
        }
    }
    //private void OnEnable()
    //{
    //    GameManager.Instance.OnCoinChange += ChangeScore;
    //    GameManager.Instance.OnLapChange += ChangeLaps;
    //}
}
