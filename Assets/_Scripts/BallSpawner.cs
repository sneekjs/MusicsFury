using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public OrbData defaultOrb;
    public GameObject Spawnable;
    public float RotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(CrossAttack());
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            CircleAttack();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            HalfCircle();
        }
    }

    private IEnumerator CrossAttack()
    {
        
        for (int i = 0; i < 10; i++)
        {
            Quaternion bulletRot = transform.rotation;
            for (int x = 0; x < 4; x++)
            {
                Orb data = Instantiate(Spawnable, transform.position, bulletRot).GetComponent<Orb>();
                bulletRot *= Quaternion.Euler(0, 45, 0);
                data.StartData = defaultOrb;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CircleAttack()
    {
        Quaternion bulletRot = transform.rotation;
        for (int x = 0; x < 190; x++)
        {
            Orb data = Instantiate(Spawnable, transform.position, bulletRot).GetComponent<Orb>();
            data.StartData = defaultOrb;
            bulletRot *= Quaternion.Euler(0, 2, 0);
        }
    }

    private void HalfCircle()
    {
        Quaternion bulletRot = transform.rotation;
        bool spawn = false;
        for (int x = 0; x < 190; x++)
        {
            if (x%3 == 0)
            {
                spawn = !spawn;
                Debug.Log(spawn);
            }
            if (spawn)
            {
                Orb data = Instantiate(Spawnable, transform.position, bulletRot).GetComponent<Orb>();
                data.StartData = defaultOrb;
            }
            bulletRot *= Quaternion.Euler(0, 2, 0);
        }
    }
}
