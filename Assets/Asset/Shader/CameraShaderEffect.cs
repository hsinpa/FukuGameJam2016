using UnityEngine;

[ExecuteInEditMode]
public class CameraShaderEffect : MonoBehaviour {
    public Material EffectMaterial;

    void OnRenderImage(RenderTexture src, RenderTexture dst) {
        Graphics.Blit(src, dst, EffectMaterial);
    }
}