using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BathroomLightFlickerEffect : MonoBehaviour
{
    public GameObject[] lights;
    public float time;

    void Start()
    {

    }

    void Update()
    {

        time += Time.deltaTime;

        if (time > 0.10f)
        {
            int idx = Random.Range(0, lights.Length);

            lights[idx].SetActive(true);

            int idx2 = Random.Range(0, lights.Length);

            lights[idx2].SetActive(false);

            time = 0;
        }
    }
}
