using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CameraController : MonoBehaviour
{
    public string sceneName;
    public ParticleSystem particles;
    public GameObject fadeBG;
    public float fadeDuration;

    public float fadeBGAlpha = 0f;
    float elapsedTime = 0f;
    bool animStarted;


    public void StartGame() {
        //fadeBG.GetComponent<Renderer>().material.SetColor("_Color", Color.black);
        if (!animStarted)
        {
            animStarted = true;
            StartCoroutine(AsyncStart());
        }
    }

    IEnumerator AsyncStart()
    {
        var main = particles.main;
        main.startColor = new Color(0, 0, 0, 0.0f);
        var col = particles.colorOverLifetime;
        col.enabled = true;

        Gradient grad = new Gradient();
        grad.SetKeys(new GradientColorKey[] { new GradientColorKey(Color.white, 0.0f) }, new GradientAlphaKey[] { new GradientAlphaKey(0.0f, 0.0f) });
        col.color = grad;

        Renderer bgRenderer = fadeBG.GetComponent<Renderer>();
        Material material1 = bgRenderer.material;

        Color startColor = material1.color;
        Color destColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

        while (fadeBGAlpha < 1f)
        {
            //float lerp = Mathf.PingPong(Time.time, fadeDuration) / fadeDuration;
            //bgRenderer.material.Lerp(material1, material2, lerp);
            Color lerpedColor = Color.Lerp(startColor, destColor, elapsedTime / fadeDuration);
            elapsedTime += Time.deltaTime;
            bgRenderer.material.SetColor("_Color", lerpedColor);
            fadeBGAlpha = lerpedColor.a;

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(0.5f);

        SceneManager.LoadScene(sceneName);

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }
}
