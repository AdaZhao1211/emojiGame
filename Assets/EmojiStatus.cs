using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EmojiStatus : MonoBehaviour {
    public int[] emojiValues;
    public GameObject[] emojisss;
    public GameObject[] blanksss;
    public GameObject levelValue;

    // 1006 added
    public Text[] typeCount;
    int[] emojiType;
    int[] typeCountNum;
	// Use this for initialization
	void Start () {
        emojiValues = new int[5]; //number of emojis [0, 0, 0, 0]
        emojiType = new int[] { 0, 0, 1, 2, 2};
        typeCountNum = new int[] { 2, 1, 2 };
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void Placed(int[] info)
    {
        // info = {2, 1} = {emojiIndex, blankIndex}
        // info[0] = emojiIndex = 2
        // info[1] = blankIndex = 1
        // emojiValues[2] = 1
        emojiValues[info[0]] = info[1];
        // [0, 0, 1, 0]
        int thisEmojiType = emojiType[info[0]];

        typeCountNum[thisEmojiType] -= 1; // typeCountNum = {2, 0, 2}

        typeCount[thisEmojiType].text = typeCountNum[thisEmojiType].ToString();
    }

    void Cancelled(int emojiIndex)
    {
        emojiValues[emojiIndex] = 0;
        typeCountNum[emojiType[emojiIndex]] += 1;  // {2, 1, 2}
        typeCount[emojiType[emojiIndex]].text = typeCountNum[emojiType[emojiIndex]].ToString();
    }


    void PutBack(int emojiIndex)
    {
        emojisss[emojiIndex].SendMessage("EmojiBack");
        
    }

    void Check()
    {
        
        int placedEmoji = 0;
        foreach (int i in emojiValues)
        {
            if(i != 0)
            {
                placedEmoji++;
            }
            Debug.Log(i);
        }
        // placedEmoji = 1 
        // placedEmoji = 2

        if(placedEmoji == 2 && blanksss[0].activeSelf)
        {
            // check correctness
            // [0, 1, 0, 2]
            if(emojiValues[1] == 1 && emojiValues[3] == 2)
            {
                Debug.Log("correct 2");

                emojisss[1].SetActive(false);
                emojisss[3].SetActive(false);
                blanksss[0].SetActive(false);
                blanksss[1].SetActive(false);
                blanksss[2].SetActive(true);
            }
            else if (emojiValues[1] == 2 && emojiValues[0] == 1)
            {
                // nicolas~~
            }
            else
            {
                Debug.Log("wrong 2");
                //wrong, alert and put back those two
                blanksss[0].GetComponent<Animator>().SetTrigger("shakeshake");
                for (int i = 0; i < emojiValues.Length; i++)
                {
                    if (emojiValues[i] == 1 || emojiValues[i] == 2)
                    {
                        PutBack(i);
                        Cancelled(i);
                        
                    }
                }
            }

        }

        if(placedEmoji == 3)
        {
            if(emojiValues[2] == 3) //[0, 1, 3, 2]
            {
                // correct
                levelValue.SendMessage("Plus"); // 0 => 1
               SceneManager.LoadScene("level choose", LoadSceneMode.Single);

            }
        }
    }
}
