using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bakery : MonoBehaviour
{
    bool isBuilded = false;
    Score score;
    SpriteRenderer sr;
    [SerializeField] GameObject bakeryBuildText;
    float timeBetweenBakes = 3f;
    bool touchingPlayer;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(touchingPlayer && !isBuilded && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("dotykam piekarni");
            BuildBakery();
        }
    }

    public void BuildBakery()
    {
        if(score.wood >= 200)
        {
            score.wood -= 200;
            score.woodText.text = score.wood.ToString();
            bakeryBuildText.SetActive(false);
            sr.color = new Color(255, 255, 255, 255);
            isBuilded = true;
            StartCoroutine(BakeTime());
        }
    }

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

    IEnumerator BakeTime()
    {
        while (isBuilded)
        {
            yield return new WaitForSeconds(timeBetweenBakes);
            score.AddBread(1);
        }      
    }
}
