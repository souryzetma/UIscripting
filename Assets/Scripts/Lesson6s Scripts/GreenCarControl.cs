using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class GreenCarControl : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    [SerializeField]
    Transform gate;
    [SerializeField]
    [Range(1000, 5000)]
    float speed;
    [SerializeField]
    [Range(1200, 2000)]
    float turnSpeed;
    float turn, move;
    //public static float damaged = 0;
    //public static float fuel = 100;
    //public static int laps = 0;
    bool getIt = false;

    int stuffLayerID;
    void Start()
    {
        stuffLayerID = LayerMask.NameToLayer("Hurt");

        rb = GetComponent<Rigidbody>();
        transform.position = new Vector3(gate.position.x, transform.position.y, gate.position.z * 5);
        transform.rotation = Quaternion.LookRotation(gate.position - transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        turn = Input.GetAxis("Horizontal");
        move = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            getIt = true;
        }
    }
    void FixedUpdate()
    {
        if (GameManager.Instance.getFuel() >= 20)
        {
            rb.AddForce(transform.forward * speed * move);
            rb.AddTorque(transform.up * turn * turnSpeed);
        }

        if (getIt)
        {
            if (transform.position.y < 7)
            {
                rb.AddForce(Vector3.up * 7.5f, ForceMode.VelocityChange);
                getIt = false;
            }
        }
    }

    public float getSpeed()
    {
        return Math.Abs(speed * move * 0.02f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        if (collision.gameObject.layer == stuffLayerID)
        {
            if (GameManager.Instance.getDamaged() == 95)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            GameManager.Instance.setDamaged(GameManager.Instance.getDamaged() + 5);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (GameManager.Instance.GetFlag())
        {
            if (collision.gameObject == GameManager.Instance.AllPaths()[GameManager.Instance.Index()])
            {
                GameManager.Instance.Index(GameManager.Instance.Index() + 1);
                if (GameManager.Instance.Index() == 4)
                {
                    GameManager.Instance.SetFlag(false);
                }
            }
        }
    }
}
