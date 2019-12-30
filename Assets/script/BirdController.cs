using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour {
    private bool didFlap;
    private Rigidbody2D myBody;
    public bool isAlive;
    float x;
    public bool L = false;
    public bool R = true;
    public bool firstTime = true;
    private Animator anim;
    public static BirdController instance;
    private int point = 0;
    public AudioSource audio;
    public AudioClip fly;
    public AudioClip ping;
    public AudioClip die;
    public GameObject shield;
    public GameObject shieldAnim;
    public bool isShield;
    public int time = 0;
    public bool repondShield;
    public GameObject ball;
    public GameObject patical;
    GameObject tmp;
    // Use this for initialization
    void Start () {
        time = 0;
        print(anim.GetLayerName(0));
        
	}

    void FixedUpdate()
    {
        _BirdMoveMent();
        if(isShield == false)
        {
           shield.SetActive(false);
           shieldAnim.SetActive(false);
        }
        if(isShield == true)
        {
            time++;
        }
        if(time == 500)
        {
            time = 0;
            isShield = false;
        }
        if(time >= 350)
        {
            shield.SetActive(false);
            shieldAnim.SetActive(true);
        }
    }

    void _MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Awake()
    {
        repondShield = false;
        isShield = false;
        isAlive = true;
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        _MakeInstance();
        shield.SetActive(true);
        L = false;
        R = true;
    }

    public void _flapBT()
    {
        if(tmp != null)
        {
            Destroy(tmp);
        }
        float x;
        if (this.transform.localRotation.y == 0)
        {
            x = -0.5f;
        }
        else
        {
            x = 0.5f;
        }
        Vector3 pos = new Vector3(this.transform.position.x + x, this.transform.position.y, this.transform.position.z);
        GameObject a = Instantiate(patical,pos,Quaternion.identity,this.transform);
        a.SetActive(true);
        tmp = a;
        //if(this.transform.localRotation.y == 0)
        //{
        //    a.transform.localScale = new Vector3(-1, 1, 1);
        //}
        //else
        //{
        //    a.transform.localScale = new Vector3(1, 1, 1);
        //}
        didFlap = true;
        
    }

    void _BirdMoveMent()
    {
        if (isAlive == true)
        {
            if (didFlap == true)
            {
                //Instantiate(ball, transform.position, Quaternion.identity);
                didFlap = false;
                anim.SetTrigger("fly");
                audio.PlayOneShot(fly);
                if (R == true)
                {
                    myBody.velocity = new Vector2(3,5f);
                }
                if(L == true)
                {
                    myBody.velocity = new Vector2(-3,5f);
                }
                anim.SetTrigger("normal");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (point % 10 == 0 && point % 5 == 0 && point >= 25 && point % 3 == 0 || point == 11 || point == 40)
        {
            repondShield = true;
        }
        if(other.gameObject.tag == "wallR")
        {
            audio.PlayOneShot(ping);
            point++;
            if (GameController.instance != null)
            {
                GameController.instance._SetPoint(point);
            }
            firstTime = false;
            transform.rotation = Quaternion.Euler(0, 180, 0);
            L = true;
            R = false;
            if(SpawnL.instance != null)
            {
                SpawnL.instance.d1 = 30;
            }
        }
        if (other.gameObject.tag == "wallL")
        {
            audio.PlayOneShot(ping);
            point++;
            if (GameController.instance != null)
            {
                GameController.instance._SetPoint(point);
            }
            transform.rotation = Quaternion.Euler(0, 0, 0);
            R = true;
            L = false;
            if (Spawn.instance != null)
            {
                Spawn.instance.d = 30;
            }
        }
        if(other.gameObject.tag == "destroy")
        {
            if(isShield == false)
            {
                if (isAlive == true)
                {
                    audio.PlayOneShot(die);
                    isAlive = false;
                    anim.SetTrigger("died");
                    if (GameController.instance != null)
                    {
                        GameController.instance.endG(point);
                    }
                    //Time.timeScale = 0;
                }
                if (other.gameObject.name == "gaiT")
                {
                    Time.timeScale = 0;
                }
            }
            if(isShield == true)
            {
                if (R == true)
                {
                    audio.PlayOneShot(ping);
                    point++;
                    if (GameController.instance != null)
                    {
                        GameController.instance._SetPoint(point);
                    }
                    firstTime = false;
                    transform.rotation = Quaternion.Euler(0, 180, 0);
                    L = true;
                    R = false;
                    if (SpawnL.instance != null)
                    {
                        SpawnL.instance.d1 = 30;
                    }
                }
                else if (L == true)
                {
                    audio.PlayOneShot(ping);
                    point++;
                    if (GameController.instance != null)
                    {
                        GameController.instance._SetPoint(point);
                    }
                    transform.rotation = Quaternion.Euler(0, 0, 0);
                    R = true;
                    L = false;
                    if (Spawn.instance != null)
                    {
                        Spawn.instance.d = 30;
                    }
                }
                
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "shield" && isAlive == true)
        {
            time = 0;
            shield.SetActive(true);
            isShield = true;
            other.gameObject.SetActive(false);
        }
    }

}
