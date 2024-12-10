Shader "Custom/ScreenEdgeShading" {


    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
    }


    SubShader {
        Tags { "Queue"="Overlay" }
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"


            sampler2D _MainTex;
            struct appdata_t {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
            };


            struct v2f {
                float4 vertex : SV_POSITION;
                float2 texcoord : TEXCOORD0;
            };


            v2f vert(appdata_t v) {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.texcoord = v.texcoord;
                return o;
            }


            fixed4 frag(v2f i) : SV_Target {
                float2 center = float2(0.5, 0.5);
                float dist = distance(i.texcoord, center);
                float vignette = smoothstep(0.4, 0.6, dist);
           
                fixed4 originalColor = tex2D(_MainTex, i.texcoord);
               
                return lerp(originalColor, fixed4(0, 0, 0, 1), vignette);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
}


