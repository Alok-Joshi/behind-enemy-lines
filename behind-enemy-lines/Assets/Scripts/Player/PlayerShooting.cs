using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // Start is called before the first frame update
    private Camera cam;
    
    public GameObject gunBarrel;
    public int BulletSpeed = 40;
    void Start()
    {
        cam = GetComponent<PlayerLook>().cam;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("player shoot");
            
            GameObject bullet = GameObject.Instantiate(Resources.Load("Prefabs/Bullet") as GameObject, gunBarrel.transform.position, this.transform.rotation);
            Vector3 shootDirection = (this.transform.position - gunBarrel.transform.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = this.transform.forward * 40;
            
        }
    }
}
