using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragEmoji : MonoBehaviour {
    Rigidbody2D rb;
    Transform trans;
    Vector3 originalPos;
    GameObject blankspace;
    bool blankSpaceCollision;
    GameObject emojiStatus; // empty god view
    public int emojiIndex;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        blankSpaceCollision = false;
        // 2. get the original position of the emoji
        originalPos = GetComponent<Transform>().position;
        emojiStatus = GameObject.Find("Status");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseDrag()
    {        
        trans = GetComponent<Transform>();
        Vector3 mousePos = Input.mousePosition; //(3.0, 2.0, 5.4)
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePos);
        objPosition.z = 0.0f;
        rb.velocity = (objPosition - trans.position) *20;
    }

    void OnMouseUp()
    {
        int[] emojiValues = emojiStatus.GetComponent<EmojiStatus>().emojiValues;

        rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
        if (blankSpaceCollision)
        {
            // magnet visually
            Vector3 objPosition = blankspace.transform.position;
            objPosition.z = 0.0f;
            transform.position = objPosition;

            //check if there is already an emoji, if so, put it back

            for (int i = 0; i < emojiValues.Length; i++)
            {
                // myindex = 2, blank = 1, [0, 1, 0, 0]
                if (emojiValues[i] == blankspace.GetComponent<triggerScript>().blankIndex) //an emoji is already on the blank space
                {
                    // put back
                    emojiStatus.SendMessage("PutBack", i);
                    emojiStatus.SendMessage("Cancelled", i);
                    // [0, 0, 0, 0]                
                }
            }
            //magnet logically

            int[] info = { emojiIndex, blankspace.GetComponent<triggerScript>().blankIndex }; // info = [2, 1]
            emojiStatus.SendMessage("Placed", info);
            // [0, 0, 1, 0], emojiIndex = 2, blankspaceIndex = 1


            // check blankspace status
            emojiStatus.SendMessage("Check");

        }
        else
        {
            // 3. else, put it to the original place
            transform.position = originalPos;
        }

        //for (int i = 0; i < emojiValues.Length; i++)
        //{
        //    Debug.Log(emojiValues[i]);
        //}
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 1. check if it is the blank space object

        if(other.tag == "blank")
        {
            blankSpaceCollision = true;
            blankspace = other.gameObject;
        }
    }

    
    void OnTriggerExit2D(Collider2D other)
    {
        blankSpaceCollision = false;
    }

    void EmojiBack()
    {
        transform.position = originalPos;
    }
}
