using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlollowPlayer : MonoBehaviour
{

    [SerializeField] GameObject player;
    public float offSet = 0.5f;


    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x <= 6.3f && player.transform.position.x >= -6.32f)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + offSet, -10);
        }
    }
}
