using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animals : MonoBehaviour
{
    Rigidbody2D bodyanimal;
    [SerializeField] float velocidad_eje_x;
    [SerializeField] float vida;
    float minX, maxX, maxY, minY;
    // Start is called before the first frame update
    void Start()
    {
        bodyanimal = GetComponent<Rigidbody2D>();
        Vector2 esqSupIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        minX = esqSupIzq.x;
        minY = esqSupIzq.y;

        Vector2 esqSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = esqSupDer.x;
        maxY = esqSupDer.y;
    }

    // Update is called once per frame
    void Update()
    {

        bodyanimal.velocity = new Vector2(velocidad_eje_x, bodyanimal.velocity.y);
        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY));
        if (bodyanimal.position.x == maxX) {
            velocidad_eje_x = -velocidad_eje_x;
        }
        if (bodyanimal.position.x == minX)
        {
            velocidad_eje_x = -velocidad_eje_x;
        }
        if (vida == 0) {
            Destroy(gameObject);
        }
    }
    //contacto entre dos objetos para animales
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name.Contains("bullet"))
        {
            vida = vida - 1;
        }
        


    }
}
