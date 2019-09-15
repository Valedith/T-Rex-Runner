using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="REX")
        {
            Debug.Log("Game Over");
        }
    }

}
