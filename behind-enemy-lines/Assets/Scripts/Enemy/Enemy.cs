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
    private GameObject player;
    public float sightDistance = 20f;

    public float fieldOfView = 85f;
    public float eyeHeight;

    public Transform gunBarrel;
    [Range(0.1f,10)]
    public float fireRate;
    
    public GameObject Player { get => player; }

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent <NavMeshAgent> ();
        stateMachine.Initialise();
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }
    public bool CanSeePlayer()
    {
        if(player != null)
        {
            //is the player close enough to be seen?
            if(Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if(angleToPlayer >= -fieldOfView && angleToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up*eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if(Physics.Raycast(ray,out hitInfo, sightDistance))
                    {
                        if(hitInfo.transform.gameObject == player)
                        {
                            
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }
                    
                }
            }
        }
        return false;
    }
}
