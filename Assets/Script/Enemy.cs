using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static BLINK.AnimationDemo;


public class Enemy : MonoBehaviour {
    private GameObject player;
    public Animator animator;
    public float speed;
    float obstacleRange = 5.0f;
    CharacterController characterController;
    public bool attack_animation;
    public bool isAlive;
    bool isAttacking;
    bool hasPerformedAnimation;
    public NavMeshAgent agent; 
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Run Forward", true);
        characterController = GetComponent<CharacterController>();
        isAlive = true;
        isAttacking = false;
        hasPerformedAnimation = false;
        player = GameObject.Find("Player");
        speed = Random.Range(4, 6);
        attack_animation = false;
        agent=GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isAlive)
        {
            agent.SetDestination(player.transform.position);
            //transform.LookAt(player.transform);
            Vector3 movement = (player.transform.position - transform.position).normalized;
            movement.y = -9.08f;
            //characterController.Move(movement * speed * Time.deltaTime);
            //transform.Translate(movement * speed * Time.deltaTime);
            if (!attack_animation)
            {
                animator.SetBool("Run Forward", true);
            }
        }
        else
        {
            agent.isStopped = true;
            animator.SetBool("Run Forward", false);
        }


        //casting ray
        Ray ray=new Ray(transform.position+new Vector3(0,1,0), transform.forward);
        RaycastHit hit;
        
        if (Physics.SphereCast(ray,0.75f,out hit))
        {
            ///Debug.DrawLine(ray.origin, hit.point, Color.red);
            if (hit.collider.CompareTag("Player"))
            {

                if(hit.distance<1.5f)
                {
                    if (!hasPerformedAnimation)
                    {
                        attack_animation = true;
                        float random = Random.Range(0, 4);
                        if (random == 0)
                        {
                            animator.SetTrigger("Attack6");
                        }
                        else if (random == 1)
                        {
                            animator.SetTrigger("Attack2");
                        }
                        else if (random == 2)
                        {
                            animator.SetTrigger("Attack3");
                        }
                        else if (random == 3)
                        {
                            animator.SetTrigger("Attack5");
                        }
                        else
                        {
                            animator.SetTrigger("Buff");
                        }
                        hasPerformedAnimation = true;
                    }
                }
                else
                {
                    hasPerformedAnimation=false;
                    attack_animation=false;
                }
            }
            if (!hit.collider.CompareTag("Ground")&&!hit.collider.CompareTag("Player")&& !hit.collider.CompareTag("Gun"))
            {

                if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    //transform.Rotate(0, angle, 0);
                }
            }
        }
        
    }

   
}
