using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingText : MonoBehaviour
{
    public GameObject player;
    private bool nearPlayer;
    private Animator textAnimator;

    // Start is called before the first frame update
    void Start()
    {
        textAnimator = GetComponent<Animator>();
        textAnimator.enabled = false;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 10)
        {
            nearPlayer = true;
            textAnimator.enabled = true;
        }

        if (nearPlayer == true && Vector2.Distance(transform.position, player.transform.position) > 10)
        {
            textAnimator.SetBool("disappearingAnimation", true);
        } else
        {
            textAnimator.SetBool("disappearingAnimation", false);
        }
    }
}
