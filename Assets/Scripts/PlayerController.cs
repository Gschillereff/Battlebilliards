using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static float speed = 500;
    public Rigidbody rb;
    public bool boosting = false;
    public static float boostSpeed = 3000;
    public float boostTime = 2.0f;
    public float currentBoostTime;
    public float currentBoostDelayTime;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentBoostTime = 0f;
        currentBoostDelayTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void movePlayer()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement*speed*Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && !boosting && Time.time > currentBoostDelayTime)
        {
            currentBoostTime = Time.time + boostTime;
            boosting = true;
        }

        if((Time.time > currentBoostTime) && boosting)
        {
            boosting = false;
            currentBoostDelayTime = Time.time + currentBoostDelayTime;
        }

        if(boosting)
        {
            speed = boostSpeed;
        }
        else
        {
            speed = 500;
        }

    }
}
