using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Ball : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5;
    public TextMeshProUGUI rightText, leftText;
    int scoreLeft=0, scoreRight=0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        float x;  //1 -1
        int random = Random.Range(0, 10);
        if (random > 5)
            x = 1;
        else
            x = -1;
        rb.velocity = new Vector2(x, 0)*speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "player1")
        {
            float y = specialFunction(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(-1, y).normalized * speed;
            rb.velocity = dir;
        }
        if (collision.gameObject.name == "player2")
        {
            float y = specialFunction(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            Vector2 dir = new Vector2(1, y).normalized * speed;
            rb.velocity = dir;
        }
        if(collision.gameObject.name== "wallRight")
        {
            scoreLeft = scoreLeft+1;
            leftText.text = scoreLeft.ToString();
        }
        if (collision.gameObject.name == "wallLeft")
        {
            scoreRight = scoreRight + 1;
            rightText.text = scoreRight.ToString();
        }
    }





    float specialFunction(Vector2 ballPos,Vector2 posRack,float racketHeight)
    {
        return (ballPos.y - posRack.y) / racketHeight;
    }

}
