using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArealCameraStandby : MonoBehaviour
{
    //menunjuk ke object player
    [SerializeField] private Transform player;

    //menunujuk ke object tanda
    [SerializeField] private Transform bKanan;
    [SerializeField] private Transform bKiri;

    //menunjuk ke ujung gizmoz dari camera
    [SerializeField] private Transform uKanan;
    [SerializeField] private Transform uKiri;

    private float lebarLayar, tinggiLayar, jarakCam;
    private Vector2 offset;
    private Vector3 geser;
    private int pindahCam = 0;
    private bool pindahDetect = false, sudahPindah = false;


    private void Start()
    {
        offset.Set((uKanan.position.x - bKanan.position.x), (uKanan.position.y - bKanan.position.y));
        lebarLayar = uKanan.position.x - uKiri.position.x;
        tinggiLayar = uKanan.position.y - uKiri.position.y;
        jarakCam = uKanan.position.x - transform.position.x;
        geser = new Vector3();
    }

    private void Update()
    {
        bKiri.position.Set((uKiri.position.x + offset.x), (uKiri.position.y + offset.y), 0);
        //jika player melewati border kanan
        if ((player.position.x > uKiri.position.x) && (player.position.x < bKiri.position.x) && (pindahDetect == false))
        {
            pindahCam = 1;
            pindahDetect = true;
        }
        //Jika player melewati border kiri
        else if ((player.position.x > bKanan.position.x) && (player.position.x < uKanan.position.x) && (pindahDetect == false))
        {
            pindahCam = 2;
        }
        else
        {
            pindahDetect = false;
        }

        switch (pindahCam)
        {
            case 1:
                {
                    Debug.Log("case 1");
                    uKiri.position.Set(uKiri.position.x - lebarLayar, uKiri.position.y, 0);
                    uKanan.position.Set(uKanan.position.x - lebarLayar, uKanan.position.y, 0);
                    bKanan.position.Set(bKanan.position.x - lebarLayar, bKanan.position.y, 0);
                    bKiri.position.Set(bKiri.position.x - lebarLayar, bKiri.position.y, 0);
                    geser.Set((transform.position.x - jarakCam * 2), transform.position.y, transform.position.z);
                    transform.position = geser;
                    pindahCam = 0;
                    break;
                }
            case 2:
                {
                    Debug.Log("case 2");
                    uKanan.position.Set(uKanan.position.x + lebarLayar, uKanan.position.y, 0);
                    uKiri.position.Set(uKiri.position.x + lebarLayar, uKiri.position.y, 0);
                    bKiri.position.Set(bKiri.position.x + lebarLayar, bKiri.position.y, 0);
                    bKanan.position.Set((bKanan.position.x + lebarLayar), bKanan.position.y, 0);
                    geser.Set((transform.position.x + jarakCam * 2), transform.position.y, transform.position.z);
                    transform.position = geser;
                    pindahCam = 0;
                    break;
                }
        }
    }

    private void FixedUpdate()
    {
        Debug.Log(player.position.x == bKanan.position.x);
        Debug.Log((player.position.x > bKanan.position.x - 2) && (player.position.x < bKanan.position.x + 2));
        Debug.Log(player.position.x);
        Debug.Log(bKanan.position.x);
        Debug.Log(bKiri.position);
    }
}
