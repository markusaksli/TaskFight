using Doozy.Engine;
using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class ShrinkSplash : MonoBehaviour
{
    VideoPlayer video;
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        video = GetComponent<VideoPlayer>();
        StartCoroutine(Shrink());
    }

    private IEnumerator Shrink()
    {
        anim.Play("SplashFadeIn");
        yield return new WaitUntil(() => video.isPrepared);
        yield return new WaitForSeconds(3f);
        anim.Play("SplashFadeOut");
        yield return new WaitForSeconds(1f);
        GameEventMessage.SendEvent("SplashEnded");
    }
}
