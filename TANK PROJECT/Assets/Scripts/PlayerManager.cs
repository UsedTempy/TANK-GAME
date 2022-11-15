using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int spelerNummer;
    [SerializeField]
    Material inactivemat;
    [SerializeField]
    Material activemat;
    public SpriteRenderer spriterenderer;
    bool aanDeBeurt = false;

    Color green = Color.green;
    Color red = Color.red;

    public void zetBeurt(bool b)
    {
        if (b == true)
        {
            // spriterenderer.material = activemat;
            Invoke("SetTrue", 0.2f);
            spriterenderer.color = green;
        }
        else
        {
            aanDeBeurt = false;
            spriterenderer.color = red;
            // spriterenderer.material = inactivemat;
        }
    }

    void SetTrue()
    {
        aanDeBeurt = true;
    }

    private void Update()
    {
        if (aanDeBeurt == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))

            {
                Debug.Log(spelerNummer);
                GameObject.Find("TurnManager").GetComponent<TurnManager>().WisselBeurt();
            }
        }
    }
}