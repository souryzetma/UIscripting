using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateTrigger : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.Index() == 4)
        {
            GameManager.Instance.setLaps(1);
            //GreenCarControl.laps += 1;
            GameManager.Instance.setFuel(20);
            //GreenCarControl.fuel -= 20;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameManager.Instance.Coins().Count > 0 && GameManager.Instance.Index() == 4)
            {
                for (int i = 0; i < GameManager.Instance.Coins().Count; i++)
                {
                    GameManager.Instance.Coins()[i].gameObject.SetActive(true);
                }
                GameManager.Instance.Coins().Clear();
            }
            GameManager.Instance.Index(0);
            GameManager.Instance.SetFlag(true);
        }
    }
}