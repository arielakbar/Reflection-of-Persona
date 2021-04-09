using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class Yang Berisi Disaat Player Kita Collide Dengan Objek Lain
public class PlayerCollision : MonoBehaviour
{
    
    [SerializeField] private float delay = 2f;
     void OnCollisionEnter2D(Collision2D collision)
    {
        //Player Collide Dengan Musuh
        if (collision.gameObject.CompareTag ("Enemy"))
        {
            
            FindObjectOfType<GameManager>().GameOver();

        }
        //Player Collide Dengan Objek Di Finish Line
        if (collision.gameObject.CompareTag("Finish"))
        {
            
            FindObjectOfType<GameManager>().LevelComplete();
            FindObjectOfType<GameManager>().Invoke("NextLevel",delay);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Lever"))
        {
            GameObject.Find("Lever").GetComponent<Animator>().enabled = true;

            GameObject.Find("KOTAKFALL").GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

}
