/*===========================================================================================
    EnvironmentPlus Shader
	
	Shades materials based on a color, texture, and diffuse and ambient lights.
	Supports fog effects. Supports directional lights.
	
	Erick Fernandez de Arteaga - https://www.linkedin.com/in/erickfda
	Version 0.1.0
	
===========================================================================================*/

/*===========================================================================================
	Basic Shader
===========================================================================================*/
/*
	Shades materials based on a color, texture, and diffuse and ambient lights.
	Supports fog effects. Supports directional lights.
*/
Shader "COMP7051_Asg02/EnvironmentPlus"
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

		/* Spot Lights */
		_ResistAttenuation("Resist Attenuation", float) = 1.0	/* No resistance to attenuation by default. */
	}
	
	/*=======================================================================================
		SubShader
	=======================================================================================*/
	SubShader
	{
		/*-----------------------------------------------------------------------------------
			Pass 01 - Texture Mapping, Ambient, and Diffuse Light
		-----------------------------------------------------------------------------------*/
        Pass
		{
			Tags
			{
				"LightMode" = "ForwardBase"
			}

            CGPROGRAM
            
			#pragma vertex vertexShader		/* Vertex Shader */
			#pragma fragment fragmentShader	/* Fragment Shader */
			#pragma multi_compile_fog		/* Support fog effects. */

			#include "UnityCG.cginc"		/* Include Unity graphics support. */
            
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
			float _ResistAttenuation;

			float4 _MainTex_ST;
			uniform float4 _LightColor0;

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

		/*-----------------------------------------------------------------------------------
			Pass 02 - Directional Light
		-----------------------------------------------------------------------------------*/
		Pass
		{
			Tags
			{
				"LightMode" = "ForwardAdd"
			}

			Blend One One	/* Use additive blending. */

			CGPROGRAM

			#pragma vertex vertexShader		/* Vertex Shader */
			#pragma fragment fragmentShader	/* Fragment Shader */

			#include "UnityCG.cginc"		/* Include Unity graphics support. */
            
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
			float _ResistAttenuation;

			float4 _MainTex_ST;
			uniform float4 _LightColor0;
			uniform float4x4 unity_WorldToLight;
			uniform sampler2D _LightTexture0;

			/*-------------------------------------------------------------------------------
				Shader Data
			-------------------------------------------------------------------------------*/            
            /*
				Information to be passed to the vertex shader.
			*/
			struct vertexInput 
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};
			
			/*
				Information to be passed from the vertex shader to the fragment shader.
			*/
			struct fragmentInput
			{
				float4 position : SV_POSITION;
				float4 worldPosition : TEXCOORD0;
				float4 lightPosition : TEXCOORD1;
				float3 normalDirection : TEXCOORD2;
			};

			/*-------------------------------------------------------------------------------
				Shaders
			-------------------------------------------------------------------------------*/
			/*
				VERTEX SHADER
			*/
			fragmentInput vertexShader(vertexInput input)
			{
				/* Create an output variable. */
				fragmentInput output;

				/* Get normal and inverse model matrices. */
				float4x4 modelMatrix = unity_ObjectToWorld;
				float4x4 modelMatrixInverse = unity_WorldToObject;

				/* Get the position, world position, light position, and normal direction. */
				output.worldPosition = mul(modelMatrix, input.vertex);
				output.lightPosition = mul(unity_WorldToLight, output.worldPosition);
				output.normalDirection = normalize(mul(float4(input.normal, 0.0), modelMatrixInverse).xyz);
				output.position = mul(UNITY_MATRIX_MVP, input.vertex);

				/* Return the output to the fragment shader. */
				return output;
			}

			/*
				FRAGMENT SHADER
			*/
			float4 fragmentShader(fragmentInput input) : COLOR
			{
				/* Get the fragment's normal direction. */
				float3 normalDirection = normalize(input.normalDirection);

				/* Get the view direction. */
				float3 viewDirection = normalize(_WorldSpaceCameraPos - input.worldPosition.xyz);
				
				/* Create variables for light direction and attenuation. */
				float3 lightDirection;
				float attenuation;

				/* If the light source is a directional light, set attenuation and 
					direction accordingly. */
				if (0.0 == _WorldSpaceLightPos0.w)
				{
					attenuation = 1.0;
					lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				}
				/* If the light source is a point or spot light, set attenuation and 
					direction accordingly. */
				else
				{
					float3 vertexToLightSource = _WorldSpaceLightPos0.xyz - input.worldPosition.xyz;
					float distance = length(vertexToLightSource);
					attenuation = 1.0 / (distance / _ResistAttenuation);
					lightDirection = normalize(vertexToLightSource);
				}

				/* Get the diffuse reflection. */
				float3 diffuseReflection =
					attenuation * _LightColor0.rgb * _Color.rgb
					* max(0.0, dot(normalDirection, lightDirection));

				/* Create a variable for the light source's cookie attenuation. */
				float cookieAttenuation = 1.0;

				/* If the light source is directional light, set the cookie attenuation 
					accordingly. */
				if (0.0 == _WorldSpaceLightPos0.w)
				{
					cookieAttenuation = tex2D(_LightTexture0,
						input.lightPosition.xy).a;
				}
				/* If the light source is a spot light, set the cookie attenuation
					accordingly. */
				else if (1.0 != unity_WorldToLight[3][3])
				{
					cookieAttenuation = tex2D(_LightTexture0,
						input.lightPosition.xy / input.lightPosition.w
						+ float2(0.5, 0.5)).a;
				}

				/* Return the light effect of the cookie attenuation and diffuse reflection. */
				return float4(cookieAttenuation * (diffuseReflection), 1.0);
			}

			ENDCG
		}
    }
}
