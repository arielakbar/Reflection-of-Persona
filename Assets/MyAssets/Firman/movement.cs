using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 40f;
    public bool isPaused;
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement*Time.deltaTime*speed; 
        
        if(Input.GetKeyDown(KeyCode.Escape))
            if (isPaused)
            {
                FindObjectOfType<GameManager>().Pause();
                isPaused = false;
            }
            else
            {
                FindObjectOfType<GameManager>().Resume();
                isPaused = true;
            }
                
    }
}
