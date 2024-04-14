using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : BaseState
{
    private float moveTimer; //how fast enemy moves
    private float losePlayerTimer; //how long in attack state
    private float shotTimer;

    public override void Enter()
    {

    }
    public override void  Exit()
    {

    }
    public override void Perform()
    {
        if (enemy.CanSeePlayer()) //player can be seen
        {
            losePlayerTimer = 0;
            moveTimer += Time.deltaTime;
            shotTimer += Time.deltaTime;
            enemy.transform.LookAt(enemy.Player.transform);
           
            if(shotTimer > enemy.fireRate)
            {
                Shoot();
            }
            if(moveTimer > Random.Range(3, 7))
            {
                enemy.Agent.SetDestination(enemy.transform.position + (Random.insideUnitSphere * 5));
                moveTimer = 0;
            }
        }
        else
        {
            losePlayerTimer += Time.deltaTime;
            if(losePlayerTimer > 8)
            {
                //change to search state
                stateMachine.ChangeState(new PatrolState());
            }
        }
    }
    public void Shoot()
    {
        Debug.Log("Shoot");
        //store refernce to gun barrel, instatiate new bullet, add force to the bullet

        Transform gunBarrel = enemy.gunBarrel;
        GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.position, enemy.transform.rotation);
        Vector3 shootDirection = (enemy.Player.transform.position - gunBarrel.transform.position).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * 40;
        shotTimer = 0;
    }
    void Start()
    {

    }
}
