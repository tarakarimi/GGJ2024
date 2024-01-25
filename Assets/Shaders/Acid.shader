Shader "Unlit/Acid"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BounceFreq ("Bounce Frequency", float) = 1
        _BounceAmplitude ("Bounce Amplitude", float) = 1
    }
    SubShader
    {
        Tags
        {
            "Queue"="Transparent"
            "IgnoreProjector"="True"
            "RenderType"="Transparent"
            "PreviewType"="Plane"
            "CanUseSpriteAtlas"="True"
        } 
        Blend SrcAlpha OneMinusSrcAlpha
//        Blend One OneMinusSrcAlpha
        LOD 100
        ZWrite Off Cull Off Fog { Mode Off } Lighting Off

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _BounceFreq;
            float _BounceAmplitude;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                // return i.uv.x;
                float bounce = sin(i.uv.x * _BounceFreq + _Time.y) * _BounceAmplitude;
                // return sin(i.uv.x * _BounceFreq + _Time.y) * _BounceAmplitude;/
                i.uv.y += bounce;
                fixed4 col = tex2D(_MainTex, float2(i.uv.x, i.uv.y));
                return col;
            }
            ENDCG
        }
    }
}