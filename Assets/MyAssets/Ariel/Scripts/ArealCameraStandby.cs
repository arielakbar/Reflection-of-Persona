using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArealCameraStandby : MonoBehaviour
{
    //menunjuk ke object player
    [SerializeField] private Transform player;

    //menunujuk ke object tanda
    [SerializeField] private Transform borderKanan;
    [SerializeField] private Transform borderKiri;

    //menunjuk ke ujung gizmoz dari camera
    [SerializeField] private Transform ujung1;
    [SerializeField] private Transform ujung2;

    private float lebarLayar, tinggiLayar, jarakCam;
    private Vector2 offset;
    private Vector3 geser;
    private int pindahCam = 0;
    private bool pindahDetect = false;


    private void Start()
    {
        offset.Set((ujung2.position.x - borderKanan.position.x), (ujung2.position.y - borderKanan.position.y));

        borderKiri.position.Set((ujung1.position.x + offset.x), (ujung1.position.y + offset.y), 0);

        lebarLayar = ujung2.position.x - ujung1.position.x;

        tinggiLayar = ujung2.position.y - ujung1.position.y;

        jarakCam = ujung2.position.x - transform.position.x;
        geser = new Vector3();
    }

    private void Update()
    {
        //jika player melewati border kanan
        if ((player.position.x > borderKanan.position.x - 0.2) && (player.position.x < borderKanan.position.x + 0.2) && (pindahDetect == false))
        {
            pindahCam = 2;
        }
        //Jika player melewati border kiri
        else if ((player.position.x > borderKiri.position.x - 0.2) && (player.position.x < borderKiri.position.x + 0.2) && (pindahDetect == false))
        {
            pindahCam = 1;
        } else
        {
            pindahDetect = false;
        }
        
        switch (pindahCam)
        {
            case 1:
                Debug.Log("case 1");
                //mengeset border kiri sebagai border kanan yang baru
                borderKanan.position.Set(borderKiri.position.x, borderKiri.position.y, 0);
                //menggeser border kiri sebannyak lebarLayar ke kiri
                borderKiri.position.Set((borderKiri.position.x - lebarLayar), borderKanan.position.y, 0);
                transform.position.Set((transform.position.x - jarakCam * 2), transform.position.y, transform.position.z);
                break;
            case 2:
                Debug.Log("case 2");
                //mengeset border kanan sebagai border kiri yang baru
                borderKiri.position.Set(borderKanan.position.x, borderKiri.position.y, 0);
                //menggeser border kanan sebanyak nilai dari lebarLayar
                borderKanan.position.Set((borderKanan.position.x + lebarLayar), borderKanan.position.y, 0);
                //transform.position.Set((transform.position.x + jarakCam * 2), transform.position.y, transform.position.z);
                geser.Set((transform.position.x + jarakCam), transform.position.y, transform.position.z);
                transform.position = geser;
                pindahCam = 0;
                pindahDetect = true;
                break;
        }


    }

    private void FixedUpdate()
    {
        Debug.Log(player.position.x == borderKanan.position.x);
        Debug.Log((player.position.x > borderKanan.position.x - 2) && (player.position.x < borderKanan.position.x + 2));
        Debug.Log(player.position.x);
        Debug.Log(borderKanan.position.x);
    }
}
