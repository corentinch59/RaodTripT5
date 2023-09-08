Shader "Unlit/OxygenBar"
{
    Properties
    {
       [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
       _Oxygen ("Oxygen", Range(0,1)) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct MeshData
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _Oxygen;

            Interpolators vert (MeshData v)
            {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float4 frag (Interpolators i) : SV_Target
            {
                // sample the texture
                // float4 col = tex2D(_MainTex, i.uv);

                float3 oxygenBarColor = float3(0,0.25,1);
                float3 bgColor = float3(0, 0, 0);
                float oxygenChargeMask = _Oxygen > i.uv.y;
                
                float3 outColor = lerp(bgColor, oxygenBarColor, oxygenChargeMask);
                return float4(outColor, 0);
            }
            ENDCG
        }
    }
}
