Shader "Unlit/DynamoBar"
{
    Properties
    {
       [NoScaleOffset] _MainTex ("Texture", 2D) = "white" {}
       _Battery ("Battery", Range(0,1)) = 1
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
            float _Battery;

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

                float3 dynamoBarColor = lerp(float3(1, 0, 0), float3(0, 1, 0), _Battery);
                float3 bgColor = float3(0, 0, 0);
                float dynamoChargeMask = _Battery > i.uv.y;
                
                float3 outColor = lerp(bgColor, dynamoBarColor, dynamoChargeMask);
                return float4(outColor, 0);
            }
            ENDCG
        }
    }
}
