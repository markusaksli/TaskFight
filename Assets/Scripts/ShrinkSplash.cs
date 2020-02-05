using System.Collections;
using UnityEngine;

public class ShrinkSplash : MonoBehaviour
{
    Animation anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        StartCoroutine(Shrink());
    }

    private IEnumerator Shrink()
    {
        anim.Play("SplashFadeIn");
        yield return new WaitForSeconds(6f);
        anim.Play("SplashFadeOut");
    }
}
