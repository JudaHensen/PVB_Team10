using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public float waveHeight = 0.5f;

    public float waveFrequency = 1f;

    public float waveSpeed = 1f;

    public Transform ocean;

    Material oceanMat;

    Texture2D WavesDisplacement;


    void Start()
    {
        
    }

    void setVariables()
    {
        oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        WavesDisplacement = (Texture2D)oceanMat.GetTexture("_WavesDisplacement");
    }

    public float WaterHeightAtPosition(Vector3 position)
    {
        return ocean.position.y + WavesDisplacement.GetPixelBilinear(position.x * waveFrequency, position.z * waveFrequency + Time.time * waveSpeed).g * waveHeight * ocean.localScale.x;
    }

    private void OnValidate()
    {
        if (!oceanMat)
            setVariables();

        UpdateMaterial();
    }

    void UpdateMaterial()
    {
        oceanMat.SetFloat("_WaveScale", waveFrequency);
        oceanMat.SetFloat("_WaveSpeed", waveSpeed);
        oceanMat.SetFloat("_WaveStrength", waveHeight);
    }

}
