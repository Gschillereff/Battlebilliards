using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDetector : MonoBehaviour
{
    public int score;
    public int displayScore;
    public Text scoreUI;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        displayScore = 0;
        scoreUI.text = "Score: " + displayScore;
 
        StartCoroutine(ScoreUpdater());
   
    }

    private IEnumerator ScoreUpdater()
    {
        while(true)
        {
            if(displayScore < score)
            {
                displayScore++;
                scoreUI.text = "Score: " + displayScore.ToString();
            }
            yield return new WaitForSeconds(0.2f);
        }

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Ball")
        {
            score = score + 5;
           
        }
    }
}
