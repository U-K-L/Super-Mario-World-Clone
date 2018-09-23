using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIInputer {

    private bool s = false;
    private bool t = false;
    private bool r = false;
    private bool human = false;
	// Use this for initialization
	void Start () {
        Debug.Log("yes starts");
    }
	
	// Update is called once per frame
	public void Update () {
        if(human == false)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                s = true;
                Debug.Log("Right is pressed");
            }
            else
            {
                s = false;
            }

            if (Input.GetKey(KeyCode.X))
            {
                t = true;
                Debug.Log("Jump is pressed");
            }
            else
            {
                t = false;
            }
        }


    }


    public void SetInputMove(bool input)
    {
        s = input;
    }

    public void SetInputRun(bool input)
    {
        r = input;
    }

    public void SetInputJump(bool input)
    {
        t = input;
    }

    public bool GetInputMovement()
    {
        return s;
    }


    public bool GetInputJump()
    {
        return t;
    }


    public bool GetInputRun()
    {
        return r;
    }
}
