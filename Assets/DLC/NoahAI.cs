﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahAI : AIController {

    private float death = 1000f;
    private float lastJump = 0f;
    private float xsqueze = 0.8f;
    private float ysqueze = 0.1f;
    private DataStorage storage;
    // Use this for initialization
    protected override void Start () {
       DataStorage storage = new DataStorage();
        base.Start();
        death = storage.x;
        if(storage.y > 0f)
        {
            xsqueze = storage.y + 0.3f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Input.SetInputMove(true);
        Input.SetInputRun(true);

        if (character._isOnGround)
        {
            //Debug.Log("He is at: " + character.transform.position.x);

            lastJump = character.transform.position.x;

            if (character.transform.position.x >= death - xsqueze && character.transform.position.x <= death - ysqueze)
            {
                Input.SetInputJump(false);
            }
            else
            {
                Input.SetInputJump(true);
            }
            
        }

        if(character.State == SMBConstants.PlayerState.Dead)
        {

        }
    }

    public override void Dead()
    {
        death = lastJump;
        storage.x = death;
        storage.y = xsqueze;
        //Debug.Log("He died at: " + death);
    }
}
