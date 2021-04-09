using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour
{
    [SerializeField] private float speed;
    private bool movingRight = true;
   

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

   //Fungsi Saat Musuh Collide Dengan batas sehingga akan balik arah
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Putar"))
        {
            Debug.Log("PUTERBALIK");
            if (movingRight == true)
            {
                transform.eulerAngles = new Vector2(0, -180);
                movingRight = false;
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 0);
                movingRight = true;
            }
        }

    }
  
    
        
    
}
