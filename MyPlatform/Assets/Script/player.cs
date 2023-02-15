using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    
    public Animator anim;
    bool kosuyor_mu=false;
    int scor = 0;
    
    [SerializeField]
    float speed=10;
    [SerializeField]
    Rigidbody2D rb;
    [SerializeField]
    Text score_text;
    [SerializeField]
    GameObject yeniden_oyna_panel;
    [SerializeField]
    GameObject kazandiniz_panel;
    [SerializeField]
    Text panel_score_text;
    [SerializeField]
    Text k_panel_score_text;
    public static bool oyun_basladi_mi = false;
    [SerializeField]
    GameObject baslangic_panel;
    [SerializeField]
    AudioSource coin_ses;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex==0)
        {
            PlayerPrefs.DeleteKey("scor");
        }
        if (PlayerPrefs.HasKey("scor"))
        {
           
            scor = PlayerPrefs.GetInt("scor");
            score_text.text = scor.ToString();

        }
        if (GameManager.is_restart==true)
        {
            PlayerPrefs.DeleteKey("scor");
            baslangic_panel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    private void FixedUpdate()
    {
        if (oyun_basladi_mi==false)
        {
            return;
        }
        float horizontal = Input.GetAxis("Horizontal");
              move(horizontal);
        animasyon(horizontal);        
        turn_move(horizontal);     
        
    }
    //yürüme kodu
    void move(float horizontal)
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    //animasyon kodu
    void animasyon(float horizontal)
    {
        if (horizontal != 0)
        {
            kosuyor_mu = true;
        }
        else
        {
            kosuyor_mu = false;
        }
        anim.SetBool("kosuyor_mu", kosuyor_mu);
    }
    void turn_move(float horizontal)
    {
        if (horizontal > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }
        else if (horizontal < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
    }

    //çarpma iþlemleri
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            coin_ses.Play();
            score_counter(collision,1);
           

        }
        else if (collision.CompareTag("Enemy"))
        {
            death();
        }
        else if (collision.CompareTag("star"))
        {
            coin_ses.Play();
            score_counter(collision, 5);
        }
        else if (collision.CompareTag("kapi"))
        {
            
            string level = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
           

        }
        if (collision.CompareTag("son_kapi"))
        {
            kazandiniz_panel.SetActive(true);
            k_panel_score_text.text = "Score : " + scor.ToString();
            Destroy(this.gameObject);
        }


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Death"))
        {
            death();
           
        }
    }
    void score_counter(Collider2D collision,int deger)
    {
        scor += deger;
        PlayerPrefs.SetInt("scor", scor);       
        score_text.text = scor.ToString();        
        Destroy(collision.gameObject);
    }
    void death()
    {
        //transform.position = new Vector3(transform.position.x - 0.8f, transform.position.y, transform.position.z);
        transform.Rotate(new Vector3(0, 0, 90));
        Destroy(this.gameObject);
        yeniden_oyna_panel.SetActive(true);
        panel_score_text.text ="Score : " +scor.ToString();
        PlayerPrefs.DeleteKey("scor");
    }
    public void oyuna_basla()
    {
        PlayerPrefs.DeleteKey("scor");
        oyun_basladi_mi = true;
        baslangic_panel.SetActive(false);
        
    }

}
