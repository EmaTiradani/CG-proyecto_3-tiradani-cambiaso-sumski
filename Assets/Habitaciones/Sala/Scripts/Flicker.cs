using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flicker : MonoBehaviour
{

    public Light _Light;

    public float MinTime;
    public float MaxTime;
    public float FlickerTime;

    public AudioSource Audio;
    public AudioClip LightAudio;

    // Start is called before the first frame update
    void Start()
    {
        FlickerTime = Random.Range(MinTime, MaxTime);
    }

    // Update is called once per frame
    void Update()
    {
        FlickerLight();
    }

    void FlickerLight()
    {
        if (FlickerTime > 0)
        {
            FlickerTime -= Time.deltaTime;
        }
        else
        {
            _Light.enabled = !_Light.enabled;
            FlickerTime = Random.Range(MinTime, MaxTime);
            Audio.PlayOneShot(LightAudio);
        }
    }
}
