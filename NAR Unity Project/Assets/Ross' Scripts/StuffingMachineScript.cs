using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffingMachineScript : MonoBehaviour
{

    public GameObject Emitter;

    private ParticleSystem particle;

    private bool Stuffing = false;
    private int clicks = 0;
    private int requiredClicks = 15;
    // Start is called before the first frame update
    void Start()
    {
        particle = Emitter.GetComponent<ParticleSystem>();
    }

    private float simTime = 0.0f;
    private List<float> clicksTime = new List<float>();

    // Update is called once per frame
    void Update()
    {
        if (Stuffing)
        {

            /* This simTime and for loops is being used to measure clicks per second.
             * Thus making the emission go faster with higher clicks per second.
             */
            simTime += Time.deltaTime;
            for (int i = clicksTime.Count - 1; i > -1; i--)
                if (simTime - clicksTime[i] >= 1.0f)
                    clicksTime.RemoveAt(i);

            particle.emissionRate = 10.0f * (1.0f + (float)clicksTime.Count);
        }
    }
    public bool useMachine(GameObject Player)
    {

        Transform mountPoint = Player.transform.Find("pickupItem");
        if (mountPoint == null)
            return false; //No mount point, what???

        if (mountPoint.transform.Find("FlatTeddyBear") == null)
            return false; //They are not holding a flat teddy bear...

        //See if we can create something with the given ingredients?
        if (!Stuffing)
        {
            clicksTime.Clear();
            clicks = 0;
            simTime = 0.0f;
            Emitter.SetActive(true);
            Stuffing = true;
        }
        else
        {
            clicksTime.Add(simTime);
            clicks++;
            if(clicks >= requiredClicks)
            {
                //Give the player a teddy bear instead!
                Emitter.SetActive(false);
                Stuffing = false;
            }
        }

        return Stuffing;
    }
}
