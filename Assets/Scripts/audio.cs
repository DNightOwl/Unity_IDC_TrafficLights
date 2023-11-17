using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    private AudioSource source;
    private AudioClip carAudio;

    private void Awake()
    {
        carAudio = Resources.Load<AudioClip>("carAcceleration");
    }
    // Start is called before the first frame update
    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.clip = carAudio;
    }

    // Update is called once per frame
    void Update()
    {
        source.Play();
    }
}
