using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class WeedLightLightSide : MonoBehaviour
{
    public Light2D PointLight;
    public static float TimeToGlow = 2.5f;
    public float MinLight = 0;
    public float MaxLight = 1;
    void GlowEvaluate(WeedLightWeedSide.MessageInfo MessageData)
    {
        
        if (Vector2.Distance(transform.position,MessageData.Position)<MessageData.CurrentDistance)
        {
            print("Started Glowing");
            StartCoroutine("Glow");
        }
    }
    IEnumerator Glow(){
        
        float FullBrightTime = Time.time + TimeToGlow;
        while (FullBrightTime>Time.time)
        {
            float LerpValue = (FullBrightTime - Time.time)/TimeToGlow;
            PointLight.intensity = Mathf.Lerp(MinLight, MaxLight, LerpValue);
            print(FullBrightTime + ", " + Time.time + ", " + LerpValue);
            yield return null;
        }
        PointLight.intensity = MaxLight;
        yield break;
    }
}
