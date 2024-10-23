using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtLayButTrigger : MonoBehaviour
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
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.setFuel(5);
            //GreenCarControl.fuel -= 5;
            GameManager.Instance.setDamaged(GameManager.Instance.getDamaged() + 5);
            gameObject.SetActive(false);
        }
    }

}
