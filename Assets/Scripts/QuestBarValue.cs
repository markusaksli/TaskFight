using Doozy.Engine.Progress;
using UnityEngine;

public class QuestBarValue : MonoBehaviour
{
    public float value = 0.43f;
    public Progressor prog;
    void Start()
    {
        prog = GetComponent<Progressor>();
    }

    void OnEnable()
    {
        prog.InstantSetProgress(0f);
        prog.SetValue(value);
    }
}
