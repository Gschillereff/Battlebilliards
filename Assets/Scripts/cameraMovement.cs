using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    private GameObject player;
    private Vector3 offset;
    public Transform target;
    private float minFov = 15f;
    private float maxFov = 90f;
    private float sensitivity = 10f;
    private int degrees = 10;


    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = GameObject.Find("Player(Clone)");
        }
        else
        {
            transform.position = player.transform.position + offset;
        }

        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

        if(Input.GetMouseButton(1))
        {
            //Still working on this
            //transform.Rotate(offset, Input.GetAxis("Mouse X") * degrees);
            offset = new Vector3(Input.GetAxis("Mouse X"), 0, 0);
            transform.position = player.transform.position + offset;

        }

    }
}
