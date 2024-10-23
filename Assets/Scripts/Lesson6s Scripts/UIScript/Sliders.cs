using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sliders : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Slider fuelBar;
    [SerializeField]
    Slider healthyBar;

    private void Awake()
    {
        ChangeFuel("forFuel");
        ChangeHealthy("forHealth");
    }

    void Start()
    {
        GameManager.Instance.numsChange += ChangeFuel;
        GameManager.Instance.numsChange += ChangeHealthy;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeFuel(string forFuel)
    {
        if (forFuel == "forFuel")
        fuelBar.value = GameManager.Instance.getFuel();

    }
    public void ChangeHealthy(string forHealth)
    {
        if (forHealth == "forHealth")
        healthyBar.value = GameManager.Instance.getDamaged();
    }
    //private void OnEnable()
    //{
    //    GameManager.Instance.OnFuelChange += ChangeFuel;
    //    GameManager.Instance.OnHealthChange += ChangeHealthy;
    //}


    [SerializeField]
    Transform theChar;
    [SerializeField]
    Transform theHealthyBarCan;

    private void LateUpdate()
    {
        theHealthyBarCan.position = theChar.position + Vector3.up * 3;
        theHealthyBarCan.rotation = Quaternion.LookRotation(theHealthyBarCan.position - Camera.main.transform.position);
    }
}
