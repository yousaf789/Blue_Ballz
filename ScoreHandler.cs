using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    private int score = 0;
    // Start is called before the first frame update

    public int Score
    {
        get
        {
            return score;
        }
        set{
            score = value;
        }
    }
}
