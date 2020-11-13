using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Berries : MonoBehaviour
{
    Score score;
    [SerializeField] Sprite zBerries;
    [SerializeField] Sprite bezBerries;
    public bool canCollect = true;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    public void CollectBerries()
    {
        if(canCollect)
        {         
            canCollect = false;
            score.AddBerries(2);
            gameObject.GetComponent<SpriteRenderer>().sprite = bezBerries;
            StartCoroutine(Regeneracja());
        }
        
    }

    IEnumerator Regeneracja()
    {
        yield return new WaitForSeconds(10);
        gameObject.GetComponent<SpriteRenderer>().sprite = zBerries;
        canCollect = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            CollectBerries();
        }
    }
}
