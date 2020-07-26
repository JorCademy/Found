using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{
    // Declaring needed variables
    public float npcSpeed;
    private bool startWalking;
    private float secondsToWait;
    private Rigidbody2D Rb;
    private float targetPositionX;
    public float MIN_X;
    public float MAX_X;
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private bool setTimer;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();

        Rb.isKinematic = true;

        npcSpeed = 3f;

        startWalking = false;

        StartCoroutine(StartWalkingTimer());
    }

    // Update is called once per frame
    void Update()
    {
        // Making sure that the Mayor won't move when the player has 6 keys
        if (gameObject.name == "Mayor")
        {
            if (PlayerPrefs.GetInt("Keys", 0) >= 6)
            {
                startWalking = false;
            }
        }

        if (startWalking == false && setTimer == false)
        {
            StartCoroutine(StartWalkingTimer());
        }

        currentPosition = transform.position;

        if (startWalking)
        {
            transform.position = Vector3.MoveTowards(currentPosition, targetPosition, npcSpeed * Time.deltaTime);

            if (currentPosition == targetPosition)
            {
                startWalking = false;
                setTimer = false;
            }
        } 
    }

    void GeneratingRandomSeconds()
    {
        secondsToWait = Random.Range(3, 8);
    }

    void GeneratingRandomX()
    {
        targetPositionX = Random.Range(MIN_X, MAX_X);
    }

    IEnumerator StartWalkingTimer()
    {
        setTimer = true;

        GeneratingRandomSeconds();

        yield return new WaitForSeconds(secondsToWait);

        GeneratingRandomX();
        targetPosition = new Vector3(targetPositionX, currentPosition.y, 1f);

        startWalking = true;
    }
}
