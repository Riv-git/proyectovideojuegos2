using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animals : MonoBehaviour
{
    Rigidbody2D mybody;
    [SerializeField] float speed;
    [SerializeField] float vida;
    private bool dir = true;
    float minX, maxX, maxY, minY;
    // Start is called before the first frame update
    void Start()
    {
        mybody = GetComponent<Rigidbody2D>();
        Vector2 esqSupIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        minX = esqSupIzq.x;
        minY = esqSupIzq.y;

        Vector2 esqSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        maxX = esqSupDer.x;
        maxY = esqSupDer.y;
    }

    private void FixedUpdate()
    {
        changeDirection();
        if (dir)
        {
            mybody.velocity = new Vector2(speed, mybody.velocity.y);
        }
        else
        {
            mybody.velocity = new Vector2(-speed, mybody.velocity.y);
        }

    }

    public void changeDirection()
    {

        if (Mathf.Round(mybody.position.x) == Mathf.Round(minX))
        {
            dir = true;
        }
        else if (Mathf.Round(mybody.position.x) == Mathf.Round(maxX))
        {
            dir = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
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
