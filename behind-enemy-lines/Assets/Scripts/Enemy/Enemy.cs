using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    public NavMeshAgent Agent { get => agent; }
    [SerializeField] //for debugging
    private string currentState;
    public Path path;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent <NavMeshAgent> ();
        stateMachine.Initialise();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
