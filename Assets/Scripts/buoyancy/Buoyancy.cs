using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buoyancy : MonoBehaviour
{
    public float UnderWaterDrag = 3;
    public float UnderWaterAngularDrag = 1f;
    public float AirDrag = 0f;
    public float AirAngularDrag = 0.05f;
    public float floatingPower = 15f;

    WaveManager waveManager;

    Rigidbody m_Rigidbody;

    bool underwater;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        waveManager = FindObjectOfType<WaveManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float difference = transform.position.y - waveManager.WaterHeightAtPosition(transform.position);

        if(difference < 0)
        {
            m_Rigidbody.AddForceAtPosition(Vector3.up * floatingPower * Mathf.Abs(difference), transform.position, ForceMode.Force);
            if (!underwater)
            {
                underwater = true;
                SwitchState(true);
            }
        }
        else if(underwater)
        {
            underwater = false;
            SwitchState(false);
        }
    }

    void SwitchState(bool isUnderwater)
    {
        if (isUnderwater)
        {
            m_Rigidbody.drag = UnderWaterDrag;
            m_Rigidbody.angularDrag = UnderWaterAngularDrag;
        }
        else
        {
            m_Rigidbody.drag = AirDrag;
            m_Rigidbody.angularDrag = AirAngularDrag;
        }
    }
}
