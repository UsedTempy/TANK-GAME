using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public int spelerBeurt = 1;
    public GameObject speler1;
    public GameObject speler2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject[] spelers = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject g in spelers)
        {
            if (g.GetComponent<TankManager>().spelerNummer == 1)
            {
                speler1 = g;
            }
            else if (g.GetComponent<TankManager>().spelerNummer == 2)
            {
                speler2 = g;
            }
        }
        // de speler die aan de beurt is actief maken.

       Init();
    }
  
    void Init()
    {
        if (spelerBeurt == 1)
        {
            // Maak speler 1 actief
            speler1.GetComponent<TankManager>().zetBeurt(true);
            speler2.GetComponent<TankManager>().zetBeurt(false);
        }
        else if (spelerBeurt == 2)
        {
            // Maak speler 2 actief
            speler1.GetComponent<TankManager>().zetBeurt(false);
            speler2.GetComponent<TankManager>().zetBeurt(true);
        }
    }

    public void WisselBeurt()
    {
        if (spelerBeurt == 1)
        {
            spelerBeurt = 2;
            speler1.GetComponent<TankManager>().zetBeurt(false);
            speler2.GetComponent<TankManager>().zetBeurt(true);
        }
        else if (spelerBeurt == 2)
        {
            spelerBeurt = 1;
            speler1.GetComponent<TankManager>().zetBeurt(true);
            speler2.GetComponent<TankManager>().zetBeurt(false);
        }
    }
}
