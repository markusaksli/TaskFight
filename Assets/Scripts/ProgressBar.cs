using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public TMP_Text text;
    Doozy.Engine.Progress.Progressor progressor;
    float endTime;

    public float barDuration = 135;
    public float timeLeft = 75;
    
    // Start is called before the first frame update
    void Start()
    {
        this.progressor = this.GetComponent<Doozy.Engine.Progress.Progressor>();

        this.endTime = Time.time + timeLeft;
        
        this.progressor.SetMax(barDuration);
        this.progressor.SetValue(timeLeft);
    }

    // Update is called once per frame
    void Update()
    {
        float secondsLeft = (int) (this.endTime - Time.time);

        if (secondsLeft <= 0) {
            this.text.SetText("Time's up!");
            this.progressor.SetValue(0f);
            return;
        }
        
        this.progressor.SetValue(secondsLeft);
        
        if (secondsLeft < 60)
            this.text.SetText(secondsLeft + "");
        else
            this.text.SetText(string.Format("{0}:{1:00}", (int) ((int) secondsLeft / 60), (secondsLeft % 60)));
    }
}
