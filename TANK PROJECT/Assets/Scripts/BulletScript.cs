using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class BulletScript : MonoBehaviour
{
    float ttl = 5;

    [SerializeField] GameObject ExplosionParticle;
    public AudioSource source;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ttl -= Time.deltaTime;
        if (ttl <= 0)
        {
            GameObject.Find("TurnManager").GetComponent<TurnManager>().WisselBeurt();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        int playerAanBeurt = GameObject.Find("TurnManager").GetComponent<TurnManager>().spelerBeurt;

        if (playerAanBeurt == 1)
        {
            playerAanBeurt = 2;
        }
        else if (playerAanBeurt == 2)
        {
            playerAanBeurt = 1;
        }

        if (collision.gameObject.tag == "Tank")
        {
            GameObject.Find("Canvas").GetComponent<ScoreSystem>().addScore(playerAanBeurt, 10);
        }

        source.Play();

        GameObject explosionParticle = Instantiate(ExplosionParticle, gameObject.transform.position, gameObject.transform.rotation);
        explosionParticle.transform.Find("ExplosionParticle").GetComponent<ParticleSystem>().Play();

        GameObject.Find("TurnManager").GetComponent<TurnManager>().WisselBeurt();
    }
}
