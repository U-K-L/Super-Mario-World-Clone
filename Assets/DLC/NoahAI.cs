using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoahAI : AIController {

    private float death = 1000f;
    private float lastJump = 0f;
    private float xsqueze = 0.8f;
    private float ysqueze = 0.1f;
	// Use this for initialization
	protected override void Start () {

        base.Start();
        death = DataStorage.x;
        if(DataStorage.y > 0f)
        {
            xsqueze = DataStorage.y + 0.3f;
        }
	}
	
	// Update is called once per frame
	void Update () {
        Input.SetInputMove(true);
        Input.SetInputRun(true);

        if (character._isOnGround)
        {
            Debug.Log("He is at: " + character.transform.position.x);

            lastJump = character.transform.position.x;

            if (character.transform.position.x >= death - xsqueze && character.transform.position.x <= death - ysqueze)
            {
                Debug.Log("Do not jump!!!");
                Input.SetInputJump(false);
            }
            else
            {
                Input.SetInputJump(true);
            }
            
        }

        if(character.State == SMBConstants.PlayerState.Dead)
        {
            death = lastJump;
            DataStorage.x = death;
            DataStorage.y = xsqueze;
        }
    }
}
