using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject insta_kill_bullet;
    float minX, maxX, maxY, minY;
    float starttime;
    [SerializeField] float modo;
    // Start is called before the first frame update
    void Start()
    {
        
        Vector2 esqSupIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        minX = esqSupIzq.x;
        minY = esqSupIzq.y;

        Vector2 esqSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = esqSupDer.x;
        maxY = esqSupDer.y;
        starttime = Time.time;
        
    }

    // Update is called once per frame
    void Update()
    {
        //movement buttons
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(movH * speed * Time.deltaTime, movV * speed * Time.deltaTime));

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY));



        if (modo == 2)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                if (starttime + 1 < Time.time)
                {
                    starttime = Time.time;
                    //crea el objeto de el elemento bullet en la posicion transform
                    Instantiate(bullet, transform.position, transform.rotation);
                }

            }
            if (Input.GetKeyUp(KeyCode.I)) {
                modo = 0;
                Debug.Log(modo);
                
            }
        }
        else if (modo == 0)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {

                if (starttime + 3 < Time.time)
                {
                    starttime = Time.time;
                    //crea el objeto de el elemento bullet en la posicion transform
                    Instantiate(insta_kill_bullet, transform.position, transform.rotation);
                }

            }
            if (Input.GetKeyUp(KeyCode.I))
            {
                modo = 2;
                Debug.Log(modo);
            

            }
        }


    }

}

