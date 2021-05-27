using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Causticwatershader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

Properties
{
    ...

    [Header(Caustics)]
    _CausticsTex("Tex_Caustic", 2D) = "white" { }

    // Tiling X, Tiling Y, Offset X, Offset Y
    _Caustics_ST("Caustics ST", Vector) = (1, 1, 0, 0)
}

void surf(Input IN, inout SurfaceOutputStandard o)
{
    // Albedo comes from a texture tinted by color
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
    o.Albedo = c.rgb;

    // Caustics sampling
    fixed2 uv = IN.uv_MainTex * _Caustics_ST.xy + _Caustics_ST.zw;
    fixed3 caustics = tex2D(_CausticsTex, uv).rgb;

    // Add
    o.Albedo.rgb += caustics;

    // Metallic and smoothness come from slider variables
    o.Metallic = _Metallic;
    o.Smoothness = _Glossiness;
    o.Alpha = c.a;

    // Caustics
    fixed3 c1 = causticsSample(_CausticsTex, IN.uv_MainTex, _Caustics1_ST, _Caustics1_Speed);
    fixed3 c2 = causticsSample(_CausticsTex, IN.uv_MainTex, _Caustics2_ST, _Caustics2_Speed);

    o.Albedo.rgb += min(c1, c2);

    // Caustics UV
    fixed2 uv = IN.uv_MainTex * _Caustics_ST.xy + _Caustics_ST.zw;
uv += _CausticsSpeed * _Time.y;

 // RGB split
    fixed s = _SplitRGB;
    fixed r = tex2D(tex, uv + fixed2(+s, +s)).r;
    fixed g = tex2D(tex, uv + fixed2(+s, -s)).g;
    fixed b = tex2D(tex, uv + fixed2(-s, -s)).b;

    fixed3 caustics = fixed3(r, g, b);

    // Sampling
    fixed3 caustics = tex2D(_CausticsTex, uv).rgb;

// Add
o.Albedo.rgb += caustics;

[Header(Caustics)]
_CausticsTex("Caustics (RGB)", 2D) = "white" { }

// Tiling X, Tiling Y, Offset X, Offset Y
_Caustics1_ST("Caustics 1 ST", Vector) = (1, 1, 0, 0)
_Caustics2_ST("Caustics 1 ST", Vector) = (1, 1, 0, 0)

// Speed X, Speed Y
_Caustics1_Speed("Caustics 1 Speed", Vector) = (1, 1, 0, 0)
_Caustics2_Speed("Caustics 2 Speed", Vector) = (1, 1, 0, 0)

// Caustics samplings
fixed3 caustics1 = ...
fixed3 caustics2 = ...

// Blend
o.Albedo.rgb += min(caustics1, caustics2);


