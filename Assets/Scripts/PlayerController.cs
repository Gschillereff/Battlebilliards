using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  
    public float speed = 1000;
    public Rigidbody rb;
    public bool boosting = false;
    public static float boostSpeed = 3000;
    public float boostTime = 2.0f;
    public float currentBoostTime;
    public static int boostNum;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        currentBoostTime = 0f;
      
        boostNum = 0;
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


}
