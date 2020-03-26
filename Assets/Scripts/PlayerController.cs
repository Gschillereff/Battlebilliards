using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
  
    public float speed = 1000;
    public Rigidbody rb;
    public bool boosting = false;
    public static float boostSpeed = 3000;
    public float boostTime = 2.0f;
    public float currentBoostTime;
    public static int boostNum;
    public static int health;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentBoostTime = 0f;
        health = 1;
        boostNum = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isLocalPlayer)
        {
            return;
        }
        movePlayer();
        if(health == 0)
        {
            //Destroy(gameObject);
            health = 1;
            RpcRespawn();
        }
    }

    void movePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed*Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && !boosting && boostNum > 0)
        {
            currentBoostTime = Time.time + boostTime;
            boosting = true;
            boostNum--;
        }

        if((Time.time > currentBoostTime) && boosting)
        {
            boosting = false;
 
        }

        if(boosting)
        {
            speed = boostSpeed;
        }
        else
        {
            speed = 1000;
        }

    }



    [ClientRpc]
    void RpcRespawn()
    {
        if (isLocalPlayer)
        {
            Vector3 respawn = new Vector3(0, 0, 0);
            transform.position = respawn;
        }
    }

}
