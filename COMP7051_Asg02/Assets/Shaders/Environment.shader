/*===========================================================================================
    Environment Shader
	
	Shades materials based on a color, texture, and diffuse and ambient lights.
	Supports fog effects.
	
	Erick Fernandez de Arteaga - https://www.linkedin.com/in/erickfda
	Version 0.1.0
	
===========================================================================================*/

/*===========================================================================================
	Environment Shader
===========================================================================================*/
/*
	Shades materials based on a color, texture, and diffuse and ambient lights.
	Supports fog effects.
*/
Shader "COMP7051_Asg02/Environment"
{
	/*=======================================================================================
		Properties
	=======================================================================================*/
	Properties
	{
		/* Color */
		_Color ("Color", Color) = (1, 1, 1, 1)	/* Color defaults to white. */

		/* Texture */
		_MainTex ("Texture", 2D) = "white" { } /* Texture defaults to white. */

		/* Ambient Light */
		_AmbientColor("Ambient Light Color", Color) = (1, 1, 1, 1)  /* Ambient light color defaults to white. */
		_AmbientIntensity("Ambient Light Intensity", Range(0.0, 1.0)) = 1.0 /* Ambient light intensity defaults to maximum. */

        /* Diffuse Light */
        _DiffuseColor("Diffuse Light Color", Color) = (1, 1, 1, 1)  /* Diffuse light color defaults to white. */
        _DiffuseDirection("Diffuse Light Direction", Vector) = (-1.5, 1, 0, 1)
        _DiffuseIntensity("Diffuse Light Intensity", Range(0.0, 1.0)) = 1.0    /* Diffuse light intensity defaults to maximum. */
	}
	
	/*=======================================================================================
		SubShader
	=======================================================================================*/
	SubShader
	{
        Pass
		{
            CGPROGRAM
            
			#pragma vertex vertexShader
			#pragma fragment fragmentShader
			#pragma multi_compile_fog

			#include "UnityCG.cginc"
            
			/*-------------------------------------------------------------------------------
				Property Variables
			-------------------------------------------------------------------------------*/
            float4 _Color;
			sampler2D _MainTex;
			float4 _AmbientColor;
            float _AmbientIntensity;
            float4 _DiffuseColor;
            float3 _DiffuseDirection;
            float _DiffuseIntensity;

			float4 _MainTex_ST;

			/*-------------------------------------------------------------------------------
				Shader Data
			-------------------------------------------------------------------------------*/            
            /*
				Information to be passed from the vertex shader to the fragment shader.
			*/
			struct v2f
			{
				float4 position : SV_POSITION;	/* Position of the vertex. */
				float3 normal : NORMAL;			/* Normal of the vertex. */
				float2 uv : TEXCOORD0;			/* Texture coordinate for the vertex. */
				UNITY_FOG_COORDS(1) 			/* Texcoord to pass the fog amount. */
			};
			
			/*-------------------------------------------------------------------------------
				Shaders
			-------------------------------------------------------------------------------*/
			/*
				VERTEX SHADER
			*/
			v2f vertexShader(appdata_base v)
			{
				v2f o;

				/* Get the position and normal of the vertex. */
				o.position = UnityObjectToClipPos(v.vertex);
				o.normal = v.normal;

				/* Get the texture coordinate for this vertex. */
				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);

				/* Determine the amount of fog to be applied. */
				UNITY_TRANSFER_FOG(o, o.position);

				return o;
			}

			/*
				FRAGMENT SHADER
			*/
			float4 fragmentShader(v2f psIn) : SV_Target
			{
                /* Get the effect of the angle between the direction of the diffuse light 
					and the vertex's normal. */
				float4 diffuse = saturate(dot(_DiffuseDirection, psIn.normal));

				/* Get the color of the vertex's texture coordinate. */
				float4 texcol = tex2D(_MainTex, psIn.uv);
                
                /* Determine the pre-fog color for the pixel based on the texture color, diffuse angle, 
					and diffuse diffuse and ambient colors and intensities. */
                float4 color = saturate
				(
					/* Add the effects of ambient and diffuse light... */
					((_AmbientColor * _AmbientIntensity) + 
					(diffuse * _DiffuseColor * _DiffuseIntensity))
						
						/* ...multiply by the material's color... */
						* _Color
							
							/* ...and multiply by the texture color. */
							* texcol
				);

				/* Apply fog. */
				UNITY_APPLY_FOG(psIn.fogCoord, color);

				/* Return the color with fog applied. */
				return color;
			}

			ENDCG
        }
    }
}
