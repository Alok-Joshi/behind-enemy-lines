using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    public void Initialise()
    {
        ChangeState(new PatrolState());
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activeState != null)
        {
            activeState.Perform();

        }
    }
    public void ChangeState(BaseState newState)
    {
        if(activeState !=null)
        {
            //run cleanup
            activeState.Exit();
            
        }
        activeState = newState;

        if(activeState != null)
        {
            //setup new state
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();

        }
    }
}
