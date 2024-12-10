using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
/// <summary>
/// Screen edge shading (vignette effect).
/// </summary>
public class ScreenEdgeShadingEffect : MonoBehaviour
{
    private Material m_Material;
    private Shader m_Shader;


    public Shader VignetteShader
    {
        get { return m_Shader; }
    }


    private void DestroyMaterial(Material mat)
    {
        if (mat)
        {
            DestroyImmediate(mat);
            mat = null;
        }
    }


    private void CreateMaterials()
    {
        if (m_Shader == null)
        {
            m_Shader = Shader.Find("Custom/ScreenEdgeShading");
        }
       
        if (m_Material == null && m_Shader != null && m_Shader.isSupported)
        {
            m_Material = new Material(m_Shader);
            m_Material.hideFlags = HideFlags.HideAndDontSave;
        }
    }


    void OnDisable()
    {
        DestroyMaterial(m_Material);
    }


    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        CreateMaterials();
        if (m_Material != null)
        {
            Graphics.Blit(source, destination, m_Material);
        }
        else
        {
            Graphics.Blit(source, destination);
        }
    }
}



