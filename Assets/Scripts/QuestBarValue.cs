using Doozy.Engine.Progress;
using UnityEngine;

public class QuestBarValue : MonoBehaviour
{
    public Progressor prog;
    void Start()
    {
        prog = GetComponent<Progressor>();
    }

    void OnEnable()
    {
        prog.InstantSetProgress(0f);
        prog.SetValue(0.43f);
    }
}
