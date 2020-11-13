using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lumber : MonoBehaviour
{
    bool isBuilded = false;
    Score score;
    SpriteRenderer sr;
    [SerializeField] GameObject lumberBuildText;
    float timeBetweenChops = 3f;
    bool touchingPlayer;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    public void BuildLumber()
    {
        Debug.Log("Nie masz kasy");
        if(score.coins >= 20)
        {
            score.coins -= 20;
            score.coinText.text = score.coins.ToString();
            lumberBuildText.SetActive(false);
            sr.color = new Color(255, 255, 255, 255);
            isBuilded = true;
            StartCoroutine(ChopWood());
        }
    }

    private void Update()
    {
        if(touchingPlayer && Input.GetKeyDown(KeyCode.E) && !isBuilded)
        {
            BuildLumber();
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

    IEnumerator ChopWood()
    {
        while (isBuilded)
        {
            yield return new WaitForSeconds(timeBetweenChops);
            score.AddWood(1);
        }     
    }
}
