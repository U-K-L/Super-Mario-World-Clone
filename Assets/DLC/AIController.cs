using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public AIInputer Input;
    public SMBPlayer character;
    // Use this for initialization
    protected virtual void Start()
    {
        Input = new AIInputer();
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Input.Update();
    }

    public virtual void Dead() { }
}