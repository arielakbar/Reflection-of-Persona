using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        if (collision.gameObject.CompareTag("Lever"))
           {
            GetComponent<Rigidbody>().isKinematic = true;
        }
        }
}
