using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Security.Cryptography;
using System.Xml.Serialization;
using UnityEngine;

public class Barracks : MonoBehaviour
{
    bool isBuilded = false;
    Score score;
    SpriteRenderer sr;
    [SerializeField] GameObject barracksBuildText;
    bool touchingPlayer;


    private void Start()
    {
        score = FindObjectOfType<Score>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void BuildBaracks()
    {
        if(score.wood >=400 && score.coins >= 200)
        {
            score.coins -= 200;
            score.wood -= 400;
            score.coinText.text = score.coins.ToString();
            score.woodText.text = score.wood.ToString();
            barracksBuildText.SetActive(false);
            sr.color = new Color(255, 255, 255, 255);
            isBuilded = true;
        }
    }

    private void Update()
    {
        if(touchingPlayer && !isBuilded && Input.GetKeyDown(KeyCode.E))
        {
            BuildBaracks();
        }
        else if(touchingPlayer && isBuilded && Input.GetKeyDown(KeyCode.E))
        {
            score.AddArmy(1);
            score.coins -= 2;
            score.coinText.text = score.coins.ToString();
        }
    }

    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if(!isBuilded && collision.tag == "Player" &&
            Input.GetKeyDown(KeyCode.E))
        {
            BuildBaracks();
        }

        if(isBuilded && collision.tag == "Player" &&
            Input.GetKeyDown(KeyCode.E) && score.coins >=2)
        {
            score.AddArmy(1);
            score.coins -= 2;
            score.coinText.text = score.coins.ToString();
        }
    }*/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            touchingPlayer = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            touchingPlayer = false;
        }
    }
}
