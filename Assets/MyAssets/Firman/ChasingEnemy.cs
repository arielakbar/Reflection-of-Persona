using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingEnemy : MonoBehaviour

{
    [SerializeField] private Transform player;
    [SerializeField] private float range;
    [SerializeField] private float speed;
    Rigidbody2D rb;
    [SerializeField] private Transform area;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Mengambil Jarak Enemy dan Player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        //Kondisi Yang membuat enemy mengejar player atau kembali ke posisi semula
        if (distToPlayer < range)
        {
            
            ChasePlayer();
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, area.position, speed * Time.deltaTime);
        }
    }

    //Fungsi Mengejar Player
    void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            transform.eulerAngles = new Vector2(0, -180);
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 0);
            rb.velocity = new Vector2(-speed, 0);
        }
    }
}
   
