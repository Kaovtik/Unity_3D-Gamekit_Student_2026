using Gamekit3D;
using UnityEngine;

public class SurvivalMod : MonoBehaviour
{
    [SerializeField] private float thirstLevel = 100f;
    [SerializeField] private float thirstSpeed;
    [SerializeField] private float timer = 10f;

    [SerializeField] private bool thirsty;
    [SerializeField] private bool parched;

    [SerializeField] private GameObject playerObject;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerObject = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        /*
         Subtracting the current value of thirstLevel with thirstSpeed. thirstSpeed is normalized
         by using Time.deltaTime, so that it's frame rate independent.
         Math.Clamp restricts the thirstLevel between its current max value and a min value of 0
        */
        thirstLevel -= Mathf.Clamp(thirstSpeed * Time.deltaTime, 0f, thirstLevel);
       
        if (thirstLevel <= 50f && !thirsty)
        {
            Debug.Log(message:"Getting thirsty...");
            thirsty = true;
        }
        else if (thirsty && thirstLevel >= 50f)
        {
            thirsty = false;
        }
        
        if (thirstLevel <= 25f && !parched)
        {
            Debug.Log(message:"Need water!");
            parched = true;
        }
        else if (parched && thirstLevel >= 25f)
        {
            parched = false;
        }
        
        //if statement checks if thirstLevel is equal to, or lower, than 0 AND if parched = true
        if (thirstLevel <= 0 && parched)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                Damageable.DamageMessage msg = new Damageable.DamageMessage()
                {
                    amount = 1,
                    damager = this,
                    damageSource = new Vector3(x: 0, y: 0, z: 0),
                    direction = new Vector3(0, y: 0, z: 0),
                    throwing = false,
                    stopCamera = false
                };
                playerObject.GetComponent<Damageable>().ApplyDamage(msg);
                Debug.Log(message: "Damage by thirst!");
                timer = 10f;
            }
        }
    }
}
