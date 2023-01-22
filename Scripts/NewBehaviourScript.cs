using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewBehaviourScript : MonoBehaviour
{
    public ParticleSystem pickupEffect;

    AudioSource audioSource;
    public AudioClip background;
    public AudioClip WinconClip;
    public AudioClip LoseconClip;
    public AudioClip CollectClip;
    public AudioClip BeginClip;

    public TextMeshProUGUI fruitText;
    public TextMeshProUGUI timerText;
    public GameObject instructTextObject;
    public GameObject LoseTextObject;
    public GameObject WinTextObject;
    public GameObject cover;

    float tp;
    private int fruitCount = 0;
    private int timeint;
    private float timesecs = 11;
    public float speed;
    private bool gameEnd = false;

    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        fruitText.text = "Fruit: 0/10";
        audioSource.PlayOneShot(BeginClip);
        audioSource.clip = background;
        Invoke(nameof(music), 2f);
        instructTextObject.SetActive(true);
        LoseTextObject.SetActive(false);
        WinTextObject.SetActive(false);
        cover.SetActive(true);
        Invoke(nameof(roundabout), 12f);
        Invoke(nameof(roundatwo), 2f);

        //audioSource.PlayOneShot(WinconClip);
    }

    void roundabout()
    {
       // SetCountText();
        WinorLose(gameEnd);
    }

    void roundatwo()
    {
        cover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        tp = Random.Range(-8.0f, 8.0f);
        

        timeint = (int)timesecs;

        timerText.text = timeint.ToString();

        Invoke(nameof(BeginGame), 2f);
        Invoke(nameof(timer), 2f);
        //timer();

        
        //{
        //  audioSource.clip = background;
        //audioSource.Stop();
        //audioSource.clip = WinconClip;
        //audioSource.Play();
        //audioSource.PlayOneShot(WinconClip);
        //}
    }

    void BeginGame()
    {
        //audioSource.Play();
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector2.right * speed);
        }
        else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector2.left * speed);
        }
        instructTextObject.SetActive(false);
        
        
        //audioSource.clip = background;
        //audioSource.Play();
    }

    void SetCountText()
    {

        fruitText.text = "Fruit: " + fruitCount.ToString() + " /10";
        if (fruitCount > 9)
        {
            gameEnd = true;
            //WinorLose(gameEnd);
            fruitText.text = "Fruit: " + fruitCount.ToString() + "/" + fruitCount.ToString();
        }
        //else if (fruitCount <= 9)
        //{
          //  WinorLose(gameEnd);
        //}
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //pickupEffect = GetComponent<ParticleSystem>();
        if (other.tag == "fruit")
        {
            fruitCount += 1;
            SetCountText();
            //other.transform.position = transform.position + new Vector3(0f, 6f, 0f);
            other.transform.position = transform.position + new Vector3(tp, 6f, 0f);
            audioSource.PlayOneShot(CollectClip);
            this.pickupEffect.Play();
            //if (fruitCount == 1)
            //{
            //  gameEnd = true;
            //}
            //audioSource.PlayOneShot(GetCogClip);
        }
    }

    void timer()
    {
        
        if (timesecs > 0)
        {
            timesecs -= Time.deltaTime;
        }
        
    }

    void music()
    {
        
        //audioSource.Stop();
        audioSource.Play();
    }

    void WinorLose(bool test)
    {
        
        test = gameEnd;
        if(test == true)
        {
            speed = 0;
            WinTextObject.SetActive(true);
            audioSource.Stop();
            audioSource.clip = WinconClip;
            music();
            cover.SetActive(true);
        }
        if(test == false)
        {
            speed = 0;
            
            LoseTextObject.SetActive(true);
            audioSource.Stop();
            audioSource.clip = LoseconClip;
            music();
            cover.SetActive(true);
        }
    }

}
