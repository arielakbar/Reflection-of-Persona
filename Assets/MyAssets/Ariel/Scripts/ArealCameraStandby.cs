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
    private float zCamera;

    private void Start()
    {
        zCamera = transform.position.z;
        offset.Set((uKanan.position.x - bKanan.position.x), (uKanan.position.y - bKanan.position.y));
        lebarLayar = uKanan.position.x - uKiri.position.x;
        tinggiLayar = uKanan.position.y - uKiri.position.y;
        jarakCam = uKanan.position.x - transform.position.x;
        geser = new Vector3();
    }

    private void Update()
    {
        bKiri.position.Set((uKiri.position.x + offset.x), (uKiri.position.y + offset.y), zCamera);
        //jika player melewati border kiri
        if ((player.position.x > uKiri.position.x) && (player.position.x < bKiri.position.x) && (pindahDetect == false))
        {
            //pindahCam = 1;
            
        }
        //Jika player melewati border kanan
        else if ((player.position.x > bKanan.position.x) && (player.position.x < uKanan.position.x) && (pindahDetect == false))
        {
            pindahCam = 2;
            pindahDetect = true;
        }
        else
        {
            pindahDetect = false;
        }

        switch (pindahCam)
        {
            case 1:
<<<<<<< Updated upstream
                {
                    Debug.Log("case 1");
                    uKiri.position.Set(GeserUjung(uKiri.position.x, offset.x, lebarLayar, -1), uKiri.position.x, zCamera);
                    bKiri.position.Set(GeserUjung(bKiri.position.x, offset.x, lebarLayar, -1), bKiri.position.y, zCamera);
                    bKanan.position.Set(uKiri.position.x, bKanan.position.y, zCamera);
                    uKanan.position.Set(bKiri.position.x, uKanan.position.y, zCamera);
=======
                Debug.Log("case 1");
                //mengeset border kiri sebagai border kanan yang baru
                borderKanan.position.Set(borderKiri.position.x, borderKiri.position.y, 0);
                //menggeser border kiri sebannyak lebarLayar ke kiri
                borderKiri.position.Set((borderKiri.position.x - lebarLayar), borderKanan.position.y, 0);
                geser.Set((transform.position.x - jarakCam * 2), transform.position.y, transform.position.z);
                transform.position = geser;
                pindahCam = 0;
                pindahDetect = true;
                break;
            case 2:
                Debug.Log("case 2");
                //mengeset border kanan sebagai border kiri yang baru
                borderKiri.position.Set(borderKanan.position.x, borderKiri.position.y, 0);
                //menggeser border kanan sebanyak nilai dari lebarLayar
                borderKanan.position.Set((borderKanan.position.x + lebarLayar), borderKanan.position.y, 0);
                //transform.position.Set((transform.position.x + jarakCam * 2), transform.position.y, transform.position.z);
                geser.Set((transform.position.x + jarakCam*2), transform.position.y, transform.position.z);
                transform.position = geser;
                pindahCam = 0;
                pindahDetect = true;
                break;
        }
>>>>>>> Stashed changes

                    //uKiri.position.Set(uKiri.position.x - lebarLayar, uKiri.position.y, zCamera);
                    //uKanan.position.Set(uKanan.position.x - lebarLayar, uKanan.position.y, zCamera);
                    //bKanan.position.Set(bKanan.position.x - lebarLayar, bKanan.position.y, zCamera);
                    //bKiri.position.Set(bKiri.position.x - lebarLayar, bKiri.position.y, zCamera);
                    geser.Set((transform.position.x - jarakCam * 2), transform.position.y, transform.position.z);
                    transform.position = geser;
                    pindahCam = 0;
                    break;
                }
            case 2:
                {
                    Debug.Log("case 2");
                    uKiri.position.Set(bKanan.position.x, uKiri.position.y, zCamera);
                    bKiri.position.Set(uKanan.position.x, bKiri.position.y, zCamera);
                    bKanan.position.Set(GeserUjung(bKanan.position.x, offset.x, lebarLayar, 1), bKanan.position.y, zCamera);
                    uKanan.position.Set(GeserUjung(uKanan.position.x, offset.x, lebarLayar, 1), uKanan.position.x, zCamera);

                    //uKanan.position.Set(uKanan.position.x + lebarLayar, uKanan.position.y, zCamera);
                    //uKiri.position.Set(uKiri.position.x + lebarLayar, uKiri.position.y, zCamera);
                    //bKiri.position.Set(bKiri.position.x + lebarLayar, bKiri.position.y, zCamera);
                    //bKanan.position.Set((bKanan.position.x + lebarLayar), bKanan.position.y, zCamera);
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

    private float GeserUjung(float tAsal, float lebih, float jarak, float arah)
    {
        float hasil = (tAsal + jarak) - lebih;
        return hasil;
    }

}
