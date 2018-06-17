using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPlayerController : MonoBehaviour {

    public int Boundary = 10;
    public float speed = 20.0f;


    private int theScreenWidth;
    private int theScreenHeight;




	// Use this for initialization
	void Start () {

        theScreenWidth = Screen.width;
        theScreenHeight = Screen.height;

    }
	
	// Update is called once per frame
	void Update () {

        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 50.0f;

        transform.Translate(x, 0, 0);


        Debug.Log(transform.position.x);
      



        if (Input.mousePosition.x > theScreenWidth - Boundary)
        {
            transform.Translate(Time.deltaTime * speed, 0, 0);
        }

        if (Input.mousePosition.x < 0 + Boundary)
        {
            transform.Translate(-Time.deltaTime * speed, 0, 0);
        }

    }
}
