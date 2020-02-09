using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public string direction;

    public enum animations
    {
        Idle,
        Walk
    }

    public animations currentAnimation;
    public Animator Animator;

    // Start is called before the first frame update
    void Start()
    {
        currentAnimation = animations.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origPosition = transform.position;
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * speed * Time.deltaTime;

        if (Vector3.Distance(transform.position, origPosition) > 0)
        {
            SwitchToAnimation(animations.Walk, "walking");
        } else
        {
            SwitchToAnimation(animations.Idle, "idle");
        }

        if (transform.position.x < origPosition.x && direction != "left") 
        {
            direction = "left";
            transform.localScale = new Vector3(-1, 1, 0);
        } else if (transform.position.x > origPosition.x && direction != "right")
        {
            direction = "right";
            transform.localScale = new Vector3(1, 1, 0);
        }
    }

    void SwitchToAnimation(animations anim, string name)
    {
        if (currentAnimation != anim)
        {
            Animator.Play(name);
            currentAnimation = anim;
        }
    }
}
