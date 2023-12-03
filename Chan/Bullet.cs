using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody Bullet_Rigidbody;

    void Start()
    {
        Bullet_Rigidbody = GetComponent<Rigidbody>();
        Bullet_Rigidbody.velocity = transform.forward * 10f;
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
