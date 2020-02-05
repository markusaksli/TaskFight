using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProgressBar : MonoBehaviour
{
    public TMP_Text text;
    Doozy.Engine.Progress.Progressor progressor;
    float startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        this.progressor = this.GetComponent<Doozy.Engine.Progress.Progressor>();
        this.startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float fromStart = Time.time - this.startTime;

        
        this.text.SetText("00:" + (30 - (int)fromStart).ToString());




        fromStart *= 0.02f;
        //0.02 yhikut sekundis
        //0.6 yhikut kokku
        //30 sekundit timer
        this.progressor.SetProgress(0.6f - fromStart);
    }
}
