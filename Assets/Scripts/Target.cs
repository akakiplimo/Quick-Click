using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float torque = 10;
    private float xRangePos = 4;
    private float ySpawnPos = -2;

    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Destroy Object on Mouse Click like in Fruit Ninja
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    // Destroy Object once it enters the trigger of the Sensor after leaving game view to free resources
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Force
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Torque
    float RandomTorque()
    {
        return Random.Range(-torque, torque);
    }

    // Position
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRangePos, xRangePos), ySpawnPos);
    }
}
