using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Debug = UnityEngine.Debug;

public class Movement : MonoBehaviour
{
    float speed = 10.0f;
    float rotationAngle = 90.0f;
    
    public TextMeshProUGUI textBox;
    public TextMeshProUGUI messageBox;
    string lightName;
    string message;
    int countDown = 8;

    bool stop = false;
    bool green = false;
    bool red = false;
    bool amber = false;
    IEnumerator myCoroutine;
    GameObject greenLight;
    GameObject RedLight;
    GameObject AmberLight;

    private AudioSource source1;
    private AudioSource source2;
    private AudioClip carAudio;
    private AudioClip stopAudio;

    private void Awake()
    {
        carAudio = Resources.Load<AudioClip>("carAcceleration");
        stopAudio = Resources.Load<AudioClip>("car-tires");
    }
    // Start is called before the first frame update
    void Start()
    {
        source1 = gameObject.AddComponent<AudioSource>();
        source2 = gameObject.AddComponent<AudioSource>();
        source1.clip = carAudio;
        source2.clip = stopAudio;

        source1.Play();
        green = true;
        lightName = "amber light";
        greenLight = GameObject.Find("GreenLight");
        RedLight = GameObject.Find("RedLight");
        AmberLight = GameObject.Find("AmberLight");

        greenLight.SetActive(green);
        RedLight.SetActive(red);
        AmberLight.SetActive(amber);

        updateText();
        
        myCoroutine = countDownLoop(1.0f);
        StartCoroutine(myCoroutine);
    }

    // Update is called once per frame
    void Update()
    {
        if (stop != true)
        {
            movement();   
        }

    }

    void movement()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name == "Rotation_Trigger")
        {
            transform.Rotate(new Vector3(0, rotationAngle, 0));
        }
        if (collision.gameObject.name == "end_Trigger")
        {
            stop = true;
            messageBox.text = "";
        }
        
    }

    void updateText()
    {
        textBox.text = countDown.ToString() + " seconds before the " + lightName;
    }

    void trafficSequence()
    {
        //
        if(green == true && countDown <= 2)
        {
            source1.Stop();
            if(!source2.isPlaying)
                source2.Play();
        }
        if (green == true && countDown == 0)
        {
            green = false;
            amber = true;
            greenLight.SetActive(green);
            AmberLight.SetActive(amber);
            countDown = 2;
            lightName = "red light";
            messageBox.text = "slow down";
            Debug.Log("slow down ");
        }
        if (amber == true && countDown > 0)
        {
            speed -= speed / 2;
            source1.Stop();
            if (!source2.isPlaying)
                source2.Play();
        }
        if (amber == true && red == false && countDown == 0)
        {
            red = true;
            amber = false;
            RedLight.SetActive(red);
            AmberLight.SetActive(amber);
            lightName = "red/amber light";
            countDown = 10;
            messageBox.text = "stop";
            Debug.Log("stop");
            stop = true;
            
        }
        if (red == true && amber == false && countDown == 0)
        {
            countDown = 2;
            amber = true;
            AmberLight.SetActive(amber);
            lightName = "green light";
            messageBox.text = "get ready to go";
            Debug.Log("get ready to go");
        }
        if (red == true && amber == true && countDown == 0)
        {
            green = true;
            amber = false;
            red = false;
            greenLight.SetActive(green);
            RedLight.SetActive(red);
            AmberLight.SetActive(amber);
            lightName = "";
            textBox.text = "";
            countDown = 8;
            stop = false;
            source2.Stop();
            if (!source1.isPlaying)
                source1.Play();
            speed = 10.0f;
            messageBox.text = "GO !!";
            Debug.Log("go");
            StopCoroutine(myCoroutine);
        }
        //
    }

    IEnumerator countDownLoop(float waitForSeconds)
    {
        while(true)
        {
            updateText();
            trafficSequence();   
            countDown--;
           
            yield return new WaitForSeconds(waitForSeconds);
        }
    }

    
}
