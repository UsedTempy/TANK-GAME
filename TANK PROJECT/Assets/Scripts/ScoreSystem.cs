using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    int player1;
    [SerializeField]
    int player2;

    public Text p1Text;
    public Text p2Text;

    // Start is called before the first frame update

    public void addScore(int player, int score)
    {
        if (player == 1)
        {
            player1 += score;
        }
        else if (player == 2)
        {
            player2 += score;
        }
    }

    // Update is called once per frame
    void Update()
    {
        p1Text.text = "Score: " + player1.ToString();
        p2Text.text = "Score: " + player2.ToString();
    }
}
