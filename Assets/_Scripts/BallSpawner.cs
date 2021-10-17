using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public OrbData defaultOrb;
    public GameObject Spawnable;
    public GameObject AirdropSpawnable;
    public float RotationSpeed;
    public List<AttackData> testAttacks = new List<AttackData>();
    public bool testMode;
    public List<AttackData> attacks = new List<AttackData>();

    private void Start()
    {
        StartCoroutine(AttackPattern());
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * RotationSpeed);
    }

    private IEnumerator AttackPattern()
    {
        yield return new WaitForSeconds(1f);
        if (testMode)
        {
            for (int i = 0; i < testAttacks.Count; i++)
            {
                switch (testAttacks[i].type)
                {
                    case AttackData.AttackType.Cross:
                        StartCoroutine(CrossAttack(testAttacks[i].orbBehaviour));
                        break;
                    case AttackData.AttackType.Cirlce:
                        CircleAttack(testAttacks[i].orbBehaviour);
                        break;
                    case AttackData.AttackType.Swirl:
                        StartCoroutine(SwirlAttack(testAttacks[i].orbBehaviour));
                        break;
                    case AttackData.AttackType.SpawnAirdrop:
                        SpawnAirDrop();
                        break;
                    case AttackData.AttackType.AirDropAttack:
                        StartCoroutine(AirdropAttack(testAttacks[i].orbBehaviour));
                        break;
                    default:
                        break;
                }
                yield return new WaitForSecondsRealtime(3);
            }
        }
        else
        {
            for (int i = 0; i < attacks.Count; i++)
            {
                switch (attacks[i].type)
                {
                    case AttackData.AttackType.Cross:
                        StartCoroutine(CrossAttack(attacks[i].orbBehaviour));
                        break;
                    case AttackData.AttackType.Cirlce:
                        CircleAttack(attacks[i].orbBehaviour);
                        break;
                    case AttackData.AttackType.Swirl:
                        StartCoroutine(SwirlAttack(attacks[i].orbBehaviour));
                        break;
                    case AttackData.AttackType.SpawnAirdrop:
                        SpawnAirDrop();
                        break;
                    case AttackData.AttackType.AirDropAttack:
                        StartCoroutine(AirdropAttack(attacks[i].orbBehaviour));
                        break;
                    default:
                        break;
                }
                yield return new WaitForSecondsRealtime(3);

            }
        }
    }

    private IEnumerator CrossAttack(OrbData orbBehaviour)
    {
        
        for (int i = 0; i < 10; i++)
        {
            Quaternion bulletRot = transform.rotation;
            for (int x = 0; x < 4; x++)
            {
                Orb data = Instantiate(Spawnable, transform.position, bulletRot).GetComponent<Orb>();
                bulletRot *= Quaternion.Euler(0, 45, 0);
                data.StartData = orbBehaviour;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void CircleAttack(OrbData orbBehaviour)
    {
        Quaternion bulletRot = transform.rotation;
        for (int x = 0; x < 190; x++)
        {
            Orb data = Instantiate(Spawnable, transform.position, bulletRot).GetComponent<Orb>();
            data.StartData = orbBehaviour;
            bulletRot *= Quaternion.Euler(0, 2, 0);
        }
    }

    private IEnumerator SwirlAttack(OrbData orbBehaviour)
    {
        for (int i = 0; i < 8*8; i++)
        {
            Orb data = Instantiate(Spawnable, transform.position, transform.rotation).GetComponent<Orb>();
            data.StartData = orbBehaviour;
            yield return new WaitForSeconds(0.275f);
        }
    }

    private void SpawnAirDrop()
    {
        Vector3 spawnPoint = new Vector3(transform.position.x + Random.Range(-10.0f, 10.0f), 0, transform.position.y + Random.Range(-10.0f, 10.0f));
        GameObject go = Instantiate(AirdropSpawnable, spawnPoint, transform.rotation);
        Destroy(go, 2.0f);
    }

    private IEnumerator AirdropAttack(OrbData orbBehaviour)
    {
        for (int i = 0; i < 3; i++)
        {
            Quaternion bulletRot = transform.rotation;
            for (int x = 0; x < 12; x++)
            {
                Orb data = Instantiate(Spawnable, transform.position, bulletRot).GetComponent<Orb>();
                data.StartData = orbBehaviour;
                bulletRot *= Quaternion.Euler(0, 20, 0);
            }
            yield return new WaitForSeconds(0.1375f);
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
