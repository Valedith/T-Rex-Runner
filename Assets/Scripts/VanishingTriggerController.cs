using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanishingTriggerController : MonoBehaviour {
    [SerializeField] List<GameObject> obstacleSamples;
    List<GameObject> obstacleObjects;
    Vector3 vanishingPoint = new Vector3(-10.15f, 1.2f,0f);
    float currentHorizontalPosition = 12.0F;
	// Use this for initialization
	void Start ()
    {
        obstacleObjects = new List<GameObject>();
    }
    void Update()
    {
        if(RexController.IsStart)
        {
            CactusSpawning();
            CactusMoving();
        }
        else
        {
            //PAUSE
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "CACTUS")
        {
            obstacleObjects.RemoveAt(0);
            Destroy(collision.gameObject);
        }
    }
    void CactusSpawning()
    {

        var obstacleObjectsCount = obstacleObjects.Count;
        Debug.Log(obstacleObjectsCount);

        var spawningRate = 10;

        var MinRandomValue = 3.0F;
        var MaxRandomValue = 10.0F;        

        if (obstacleObjectsCount < spawningRate)
        {

            var randomObject = obstacleSamples[Random.Range(0, obstacleSamples.Count-1)];
            
            obstacleObjects.Add(Instantiate(randomObject, new Vector2(currentHorizontalPosition, randomObject.transform.position.y), Quaternion.identity));
            
            currentHorizontalPosition = 12.0F;

            currentHorizontalPosition = obstacleObjects[obstacleObjectsCount].transform.position.x + Random.Range(MinRandomValue, MaxRandomValue);
        }
    }
    void CactusMoving()
    {
        foreach (GameObject obstacle in obstacleObjects)
        {
            obstacle.transform.position = new Vector3(obstacle.transform.position.x - 5.0f * Time.deltaTime,
                                                      obstacle.transform.position.y,
                                                      obstacle.transform.position.z);
            Debug.Log(obstacle);
        }
    }
}
