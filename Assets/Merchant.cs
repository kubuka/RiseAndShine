using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merchant : MonoBehaviour
{
    Score score;
    public bool touchingPlayer = false;

    void Start()
    {
        score = FindObjectOfType<Score>();
    }

    public void SellThings()
    {
        var tBerries = score.berries;
        score.berries -= tBerries;
        score.berriesText.text = score.berries.ToString();
        var tBread = score.bread;
         score.bread -= tBread;
         score.breadText.text = score.bread.ToString();

        int suma = tBerries + tBread;
        score.AddCoins(suma);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && touchingPlayer)
        {
            SellThings();
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player" &&Input.GetKeyDown(KeyCode.E) )
        {
            SellThings();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            touchingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            touchingPlayer = false;
        }
    }
}
