using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MixerTest : MonoBehaviour
{
    public AudioMixer mixerToUse;

    // Start is called before the first frame update
    void Start()
    {
        mixerToUse.SetFloat("currentVolumeForFX", -10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
