using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Noise : MonoBehaviour
{
    [SerializeField] private float m_Damping = 0.2f;
    [SerializeField] private float m_NoiseAmplitude = 0.5f;

    private Transform m_Parent = null;
    private Vector3 m_currentNoise = Vector3.zero;

    private void Start()
    {
        m_Parent = transform.parent;
        transform.parent = null;
    }

    private void Update()
    {
        float GetNoise(float x)
        {
            return Mathf.Lerp(-1f, 1f, Mathf.PerlinNoise(x, Time.time));
        }

        m_currentNoise.x = GetNoise(0f);
        //m_currentNoise.y = GetNoise(.1f);
        m_currentNoise.z = GetNoise(2f);
        m_currentNoise *= m_NoiseAmplitude;

        Vector3 targetPos = Vector3.Lerp(transform.position, m_Parent.transform.position + m_currentNoise, Time.deltaTime / m_Damping);
        transform.position = targetPos;
    }
}
