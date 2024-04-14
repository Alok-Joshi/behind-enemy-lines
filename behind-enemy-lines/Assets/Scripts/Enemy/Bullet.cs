using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void onCollisonEnter(Collision collision)
    {
        Debug.Log("bullet hit");
        Transform hitTransform = collision.transform;
        if (hitTransform.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(10);

        }
        Destroy(gameObject);
    }
}
