Shader "Custom/CameraShader1" {
	Properties
	{
	    _MainTex ("Base (RGB)", 2D) = "white" {}  
	    _BlendTex ("Blend Texture", 2D) = "white" {}  
	    _Opacity ("Blend Opacity", Range(0.0, 10.0)) = 10.0  
	    _DisplaceTex("Displacement", 2D) = "white" {}
	    		_Magnitude("Magnitude", Range(0, 0.1)) = 1

	}

	SubShader {
	   Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
	   LOD 100
	 
	   BlendOp Add
	   Blend OneMinusDstColor One, One Zero // screen
	   //Blend SrcAlpha One, One Zero // linear dodge
	   ZWrite Off

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			sampler2D _MainTex;
			sampler2D _BlendTex;
			float _Opacity;
			sampler2D _DisplaceTex;
			float _Magnitude;

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f {
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert(appdata v) {
//				v2f o;
//				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
//				return o;

		         v2f o;
		         o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
		         o.uv = v.uv;

		         return o;

			}

			float4 frag(v2f i) : SV_Target {
				float2 distuv = float2(i.uv.x + _Time.x * 2, i.uv.y + _Time.x * 2);

				float2 disp = tex2D(_DisplaceTex, distuv).xy;
				disp = ((disp * 2) - 1) * _Magnitude;

			    //from the v2f_img struct  
			    fixed4 renderTex = tex2D(_MainTex, i.uv+ disp);  
   				fixed4 blendTex = tex2D(_BlendTex, i.uv);  

			    // Perform a multiply Blend mode  
			            fixed4 blendedMultiply = renderTex * blendTex;  
			  
			    // Perform a add Blend mode  
			            fixed4 blendedAdd = renderTex + blendTex;  
			  
			    // Perform a screen render Blend mode  
			    fixed4 blendedScreen = 1.0 - ((1.0 - renderTex) * (1.0 - blendTex));  
			      
			    // Adjust amount of Blend Mode with a lerp  
			    renderTex = lerp(renderTex, blendedScreen,  _Opacity);  
			      
			    return renderTex;  
			}
			ENDCG
		}
	}
}