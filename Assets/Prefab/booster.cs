using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class booster : MonoBehaviour
{
    public GameObject lightingBolt;
    
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(lightingBolt, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("lightingBolt").transform.Rotate(0, 1, 0 * Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerController.boostNum++;
            Destroy(GameObject.Find("lightingBolt"));
            StartCoroutine(Respawn(GameObject.Find("lightingBolt")));
        }

    }


    IEnumerator Respawn(GameObject gObj)
    {
        yield return new WaitForSeconds(2);
        Instantiate(lightingBolt, new Vector3(10, 1, -30), Quaternion.identity);
    }

}
