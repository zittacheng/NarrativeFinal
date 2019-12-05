Shader "ColorFixed"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		//Col("Color", Color) = (1, 1, 1, 1)

		BaseColor("Color", Color) = (1,1,1,1)
		EmptyColor("EmptyColor", Color) = (0,0,0,0)
		TR("TR", float) = 0
	}

	SubShader
	{
		Pass
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
            #include "UnityCG.cginc"

			sampler2D _MainTex;
			
			float TR;
			float4 BaseColor;
			float4 EmptyColor;

			float4 frag(v2f_img input) : COLOR
			{
				float4 base = tex2D(_MainTex, input.uv);

				float b = distance(base, BaseColor);
				if (b <= TR)
				{
					return BaseColor;
				}
				else
				{
					return EmptyColor;
				}
			}

			ENDCG
		}
	}
}
