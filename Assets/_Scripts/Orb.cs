using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public OrbData StartData;
    private float StartSpeed;
    private float DestroyDelay;
    private bool usesAcceleration;
    
    private float currentSpeed;


    // Start is called before the first frame update
    void Start()
    {
        StartSpeed = StartData.StartingSpeed;
        DestroyDelay = StartData.DestroyDelay;
        usesAcceleration = StartData.UseAcceleration;

        currentSpeed = StartSpeed;
        Destroy(gameObject, DestroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * currentSpeed * Time.deltaTime);

        if (usesAcceleration)
        {
            currentSpeed *= 1.1f;
        }
    }
}
