using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAI : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private float rotationSpeed = 50f;
    [SerializeField] float RadiusOfSatisfaction = 1f;
    [SerializeField] List<Transform> path;
    [SerializeField] int startingIndex = 0;
    private int currentIndex;

    // Start is called before the first frame update
    void Start()
    {
        currentIndex = startingIndex;
    }

    // Update is called once per frame
    void Update()
    {
        float angle;
        if (!isAligned(out angle))
        {
            Rotate(angle);
        }
        else
        {
            Move();
        }

        handlePath();
    }

    void handlePath()
    {
        if(Distance() < RadiusOfSatisfaction)
        {
            if (currentIndex + 1 == path.Count)
            {
                currentIndex = 0;
            }
            else
            {
                currentIndex++;
            }
        }
    }

    void Move()
    {
        transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
    }

    void Rotate(float angle)
    {
        float speedModifier = angle / 10f;
        transform.Rotate(0f, rotationSpeed * speedModifier * Time.deltaTime, 0f);
    }
    
    private bool isAligned(out float angle)
    {
        Vector3 targetDir = path[currentIndex].position - transform.position;
        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up) * -1;
        if (angle < 10f && angle > -10f || Distance() < RadiusOfSatisfaction * 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    float Distance()
    {
        return Vector3.Distance(transform.position, path[currentIndex].position);
    }
}
