using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreDetector : MonoBehaviour
{
    public int score;
    public int displayScore;
    public int opponentScore;
    public int displayOpponentScore;
    public Text scoreUI;
  
    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        opponentScore = 0;
        displayScore = 0;
        displayOpponentScore = 0;
        scoreUI.text = "Score: " + displayScore.ToString() + '\n' + "Opponent Score: " + displayOpponentScore.ToString();

        StartCoroutine(ScoreUpdater());
   
    }

    private IEnumerator ScoreUpdater()
    {
        while (true)
        {
           

                if (displayScore < score)
                {
                    displayScore++;
                    scoreUI.text = "Score: " + displayScore.ToString() + '\n' + "Opponent Score: " + displayOpponentScore.ToString();
                }

                if (displayOpponentScore < opponentScore)
                {
                    displayOpponentScore++;
                    scoreUI.text = "Score: " + displayScore.ToString() + '\n' + "Opponent Score: " + displayOpponentScore.ToString();
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
            score++;
            
           //Add destroy on collison to ball script
        }

        if(collision.gameObject.tag =="OpBall")
        {
            opponentScore++;
          
        }
    }
}
