using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 *A very basic template for making AI. 
 * 
 * // DataStorage stores var for latter use.
 * // character.transform.position.x    gets the character's x position.
 * // _isOnGround   Checks if player is on the ground.
 * // Input.SetInputMove(true)  Moves to the right.
 * // Input.SetInputJump(true)  Player jumps.
 * // Input.SetInputRun(true)  Makes player run.
 */
public class GeneralTemplateAI : AIController {
    private float death_pos = 1000f; //Variable to store position of death


    // Use this for initialization
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update () {

	}

    public override void Dead()
    {

    }
}
