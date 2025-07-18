// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/1 - Flat Color"
{
	Properties
	{
		_Color ("Color", Color) = (1.0, 1.0, 1.0, 1.0) 
	}
	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
 
			fixed4 _Color;
 
			struct vert_input
			{
				fixed4 vertex : POSITION;
			};
 
			struct frag_input
			{
				fixed4 pos : SV_POSITION;
			};
 
			frag_input vert(vert_input v)
			{
				frag_input vo;
				vo.pos = UnityObjectToClipPos(v.vertex);
				return vo;
			}
 
			fixed4 frag(frag_input fi) : COLOR
			{
				return _Color;
			}
			ENDCG
		}
	}
}