
using UnityEngine;

public class Fading : MonoBehaviour
{
    public Texture2D fading;
    private float fadeSpeed = 0.8f, alpa = 1f, fadeDir = -1;
    private int drawDepth = -1000;

    private void OnGUI()
    {
        alpa += fadeDir * fadeSpeed * Time.deltaTime;
        alpa = Mathf.Clamp01(alpa);

        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpa);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0,0,Screen.width, Screen.height),fading);
    }

    public float Fade(float dir)
    {
        fadeDir = dir;
        return fadeSpeed;
    }
}
