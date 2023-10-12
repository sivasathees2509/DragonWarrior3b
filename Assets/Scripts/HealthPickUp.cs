using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public int healthRestore = 20;
    public Vector3 spinRotatopnSpeed = new Vector3(0, 180, 0);

    AudioSource pickupSource;

    private void Awake()
    {
        pickupSource = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if(damageable && damageable.Health < damageable.MaxHealth)
        {
            bool wasHealed = damageable.Heal(healthRestore);

            if(wasHealed)
            {
                if(pickupSource)
                {
                    AudioSource.PlayClipAtPoint(pickupSource.clip, gameObject.transform.position, pickupSource.volume);
                }
                Destroy(gameObject);
            }
           // CharacterEvents.characterHealed(gameObject, healthRestore);
        }

    }

    private void Update()
    {
        transform.eulerAngles += spinRotatopnSpeed * Time.deltaTime;
    }
}
