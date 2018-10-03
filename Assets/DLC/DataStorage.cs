using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class DataStorage{

    public  float currentDeath = 10000f;//Tracks the current death without exception.
    public  float x = 0f;
    public  float y = 0f;

    public AIBranch root;
    public AIBranch currentNode;

    public DataStorage() {
        root = new AIBranch();
        currentNode = root;
    }

    public void reset()
    {
        currentNode = root;
    }

    public void updateNode(float position)
    {
        if (currentDeath < position)
        {
            currentNode = currentNode.next;
            currentDeath = 1000f;
        }
    }

    public void addInput(float x, float delta = 0.1f, float epsilon = 0.1f)
    {
        //Goes to the next input for mario and allocate a spot.
        currentNode.next = new AIBranch();
        currentNode = currentNode.next;

        //Sets the values.
        currentNode.x = x;
        currentNode.delta = delta;
        currentNode.epsilon = epsilon;


    }


}
