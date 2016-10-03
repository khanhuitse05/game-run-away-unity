using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class HeroController : MonoBehaviour
{
    public float timeJump = 1.0f;
    public float jumpVel = 25;
    public GameObject image;
    public ParticleSystem particle;
    public float speedRotate;
    public float fromAngle;
    public float toAngle;
    bool jump = false;
    Rigidbody2D rigib;
    public Action OnGhostDie;
    public bool isAlive;
    Vector3 posStart;
    // Use this for initialization
    void Start()
    {
        posStart = transform.position;
        rigib = gameObject.GetComponent<Rigidbody2D>();
        timeJump = GameConstants.Instance.timeJump;
        jumpVel = (-Physics2D.gravity.y) * rigib.gravityScale * (timeJump / 2);
    }
    public void reset()
    {
        gameObject.SetActive(true);
        isAlive = true;
        transform.position = posStart;
        rigib.velocity = new Vector2(0, 0);
        fromAngle = 0;
        toAngle = 0;
    }
    void GoRotate()
    {
        toAngle -= 180;
    }
    void Rotate(float _detalTime)
    {
        if (fromAngle > toAngle)
        {
            fromAngle -= speedRotate * _detalTime;
            if (fromAngle < toAngle)
            {
                fromAngle = toAngle;
            }
            image.transform.localEulerAngles = new Vector3(0.0f, 0.0f, fromAngle);
        }
        
    }
    void CheckPartical()
    {
        if (particle.isPlaying == false)
        {
            if (rigib.velocity.y == 0)
            {
                particle.Play();
            }
        }
    }
    void FixedUpdate()
    {
        if (isAlive)
        {
            updateGhost();
            Rotate(Time.deltaTime);
            if (jump && rigib.velocity.y == 0)
            {
                jump = false;
                rigib.velocity = new Vector2(0, jumpVel);
                if (particle.isPlaying)
                {
                    particle.Stop();
                }
                GoRotate();
            }
            if (transform.position.y < -10)
            {
                OnBlockDie();
            }
            CheckPartical();
        }
    }

    void updateGhost()
    {
        if (jump == false && (rigib.velocity.y == 0 || rigib.velocity.y <= (0 - jumpVel / 2)))
        {
            if (Input.touchCount > 0 || Input.GetButton("Jump"))
            {
                jump = true;
            }
#if UNITY_EDITOR
            if (Input.GetMouseButton(0))
            {
                jump = true;
            }
#endif
        }
    }
    void OnBlockDie()
    {
        isAlive = false;
        gameObject.SetActive(false);
        if (OnGhostDie != null)
        {
            OnGhostDie();
        }
    }
}
