using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsBehaviour : MonoBehaviour

{
    public GameObject powerup;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousepos = Input.mousePosition;
            mousepos.z = 2.0f;
            mousepos.y = Screen.height;
            Vector3 poweruppos = Camera.main.ScreenToWorldPoint(mousepos);
            Instantiate(powerup, poweruppos,Quaternion.identity,transform);
            Debug.Log("Mouse Left pressed at" + (poweruppos));
        }

        
            
    }
}

        


