using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    private float timeLeft = 0.0f;
    private bool resumeTimer = false;

    [SerializeField] private GameObject Scoreboard;
    [SerializeField] private Text pointsText;
    [SerializeField] private OrderSystemScript orderSystem;

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<Text>();

        //Uncomment this if you don't want to test the timer.
        startTimer(10);
    }

    // Update is called once per frame
    void Update()
    {
        if (resumeTimer)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft <= 0.0f)
            {
                Scoreboard.SetActive(true);
                pointsText.text = "Time is up\nFinal score\n" + orderSystem.score.ToString();
                resumeTimer = false;
            }
            else
            {
                text.text = Mathf.FloorToInt(timeLeft + 1.0f).ToString();
            }
        }
    }

    public void startTimer(int seconds)
    {
        timeLeft = (float)seconds;
        resumeTimer = true;
    }

}
