using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insta_kill_bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //contacto entre dos objetos con mecanicas de Collider/RigidBody
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Colisionando con" + collision.gameObject.name);
        if (collision.gameObject.name.Contains("cow"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.name.Contains("slug"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.name.Contains("wolf"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

}

