using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankManager : MonoBehaviour
{
    public float rotoationSpeed = 25;
    public float movespeed = 3;
    public float bulletSpeed = 2;
    public AudioSource source;
    public AudioClip clip;
    private float horizontal;
    public int spelerNummer;
    bool aanDeBeurt = false;
    public SpriteRenderer spriterenderer;

    TurnManager turnManager;

    [SerializeField] Transform Rotator;
    [SerializeField] Transform FirePoint;
    [SerializeField] GameObject Bullet;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        turnManager = GameObject.Find("TurnManager").GetComponent<TurnManager>();
    }

    public void zetBeurt(bool b)
    {
        if (b == true)
        {
            // spriterenderer.material = activemat;
            aanDeBeurt = true;
            spriterenderer.color = Color.green;
        }
        else
        {
            aanDeBeurt = false;
            spriterenderer.color = Color.red;
            // spriterenderer.material = inactivemat;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (aanDeBeurt == true)
        {
            //transform.Translate(Vector2.right * movespeed * Time.deltaTime * Input.GetAxis("Horizontal"));
            horizontal = Input.GetAxisRaw("Horizontal");
            Rotator.Rotate(0, 0, rotoationSpeed * Time.deltaTime * Input.GetAxis("Vertical"));

            if (Input.GetKeyDown(KeyCode.F))
            {
                GameObject b = Instantiate(Bullet, FirePoint.position, FirePoint.rotation);
                b.GetComponent<Rigidbody2D>().AddForce(FirePoint.up * bulletSpeed);

                source.PlayOneShot(clip);

                Invoke("TurnHelper", 0.1f);
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                bulletSpeed = Math.Clamp(bulletSpeed += 500, 0, 9000);
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                bulletSpeed = Math.Clamp(bulletSpeed -= 500, 0, 9000);
            }
        }
    }

    private void FixedUpdate()
    {
        if (aanDeBeurt == true)
        {
            rb.velocity = new Vector2(horizontal * movespeed, rb.velocity.y);
        }
    }

    // void TurnHelper()
    // {
    //     turnManager.WisselBeurt();
    // }
}
