// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "BlendModes/MeshDefault/Framebuffer" 
{
	Properties 
	{
		_Color ("Tint Color", Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}
		
		[MaterialToggle] 
		_IsSelectiveBlendingActive("Selective Blending", Float) = 0
	}
	
	SubShader 
	{
		Tags 
		{ 
			"Queue" = "Transparent" 
			"RenderType" = "Transparent" 
		}
		
		ZWrite Off
		Blend SrcAlpha OneMinusSrcAlpha 
		
		Pass 
		{  
			CGPROGRAM
			
			#include "UnityCG.cginc"
			#include "../BlendModes.cginc"

			#pragma target 3.0			
			#pragma multi_compile BMDarken BMMultiply BMColorBurn BMLinearBurn BMDarkerColor BMLighten BMScreen BMColorDodge BMLinearDodge BMLighterColor BMOverlay BMSoftLight BMHardLight BMVividLight BMLinearLight BMPinLight BMHardMix BMDifference BMExclusion BMSubtract BMDivide BMHue BMSaturation BMColor BMLuminosity
			#pragma vertex ComputeVertex
			#pragma fragment ComputeFragment
			
			fixed4 _Color;
			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _IsSelectiveBlendingActive;

			struct VertexInput 
			{
				float4 vertex : POSITION;
				float2 texcoord : TEXCOORD0;
			};

			struct VertexOutput 
			{
				float4 vertex : SV_POSITION;
				half2 texcoord : TEXCOORD0;
			};
			
			VertexOutput ComputeVertex(VertexInput vertexInput)
			{
				VertexOutput vertexOutput;
				
				vertexOutput.vertex = UnityObjectToClipPos(vertexInput.vertex);
				vertexOutput.texcoord = TRANSFORM_TEX(vertexInput.texcoord, _MainTex);
				
				return vertexOutput;
			}
			
			fixed4 ComputeFragment (VertexOutput vertexOutput
				#ifdef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
				, inout fixed4 fetchColor : COLOR1
				#endif
				) : SV_Target
			{
				fixed4 color = tex2D(_MainTex, vertexOutput.texcoord) * _Color;
				
				#ifdef UNITY_FRAMEBUFFER_FETCH_AVAILABLE
				fixed4 grabColor = fetchColor;
				#else
				fixed4 grabColor = fixed4(1, 1, 1, 1);
				#endif
				
				#include "../BlendOps.cginc"
			}
			
			ENDCG
		}
	}
	
	FallBack "Diffuse"
	CustomEditor "BMMaterialEditor"
}
