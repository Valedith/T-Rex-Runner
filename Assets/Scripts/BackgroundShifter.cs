using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundShifter : MonoBehaviour {
    [SerializeField] float backgroundMovingSpeed;
    string currentBackground;

    Vector2 originalTriggerPosition;
    Vector2 background1OriginalPosition;
    Vector2 background2OriginalPosition;
    
    Vector2 background1CurrentPosition;
    Vector2 background2CurrentPosition;


    GameObject objectBackground1;
    GameObject objectBackground2;
    GameObject objectRelocateTrigger;
	
    // Use this for initialization
	void Start () {
        Init();
        GetAllOriginalPositions();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (RexController.IsStart)
        {
            MovingBackgrounds();
        }
        else
        {
            //PAUSE
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "VANISHINGTRIGGER")
        {
            ShiftBackground();
            RevertTriggerPosition();
        }
    }
    void Init()
    {
        backgroundMovingSpeed = -5.0f;
        currentBackground = "BACKGROUND1";
        objectBackground1 = GameObject.FindWithTag("BACKGROUND1");
        objectBackground2 = GameObject.FindWithTag("BACKGROUND2");
        objectRelocateTrigger = GameObject.FindWithTag("SCENERESETTRIGGER");
    }
    void GetAllOriginalPositions()
    {
        originalTriggerPosition = transform.position;
        background1OriginalPosition = objectBackground1.transform.position;
        background2OriginalPosition = objectBackground2.transform.position;

    }
    void RevertTriggerPosition()
    {
        transform.position = originalTriggerPosition;
    }
    void ShiftBackground()
    {
        if (currentBackground.Equals("BACKGROUND1"))
        {
            objectBackground1.transform.position = background2OriginalPosition;
            currentBackground = "BACKGROUND2";
        }
        else if (currentBackground.Equals("BACKGROUND2"))
        {
            objectBackground2.transform.position = background2OriginalPosition;
            currentBackground = "BACKGROUND1";
        }
    }

    void MovingBackgrounds()
    {
        objectRelocateTrigger.transform.position = GameObjectHelpers.ObjectMovingHorizontally("SCENERESETTRIGGER", backgroundMovingSpeed);
        objectBackground1.transform.position = GameObjectHelpers.ObjectMovingHorizontally("BACKGROUND1", backgroundMovingSpeed);
        objectBackground2.transform.position = GameObjectHelpers.ObjectMovingHorizontally("BACKGROUND2", backgroundMovingSpeed);
    }

    //void MovingObjectHorizontally(string objectTag,float speed)
    //{
    //    if(objectTag.Equals("BACKGROUND1"))
    //    {
    //        background1CurrentPosition = objectBackground1.transform.position;
    //        background1CurrentPosition.Set(background1CurrentPosition.x + speed * Time.deltaTime, background1CurrentPosition.y);
    //        objectBackground1.transform.position = background1CurrentPosition;
    //    }
    //    if(objectTag.Equals("BACKGROUND2"))
    //    {
    //        background2CurrentPosition = objectBackground2.transform.position;
    //        background2CurrentPosition.Set(background2CurrentPosition.x + speed * Time.deltaTime, background2CurrentPosition.y);
    //        objectBackground2.transform.position = background2CurrentPosition;
    //    }
    //    if(objectTag.Equals("SCENERESETTRIGGER"))
    //    {
    //        transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
    //    }
    //}

}
