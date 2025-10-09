using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.InputSystem.Interactions;

public class PlayerController : MonoBehaviour
{
    const string IDLE = "Idle";
    const string WALK = "Walk";
    const string ATTACK = "Attack";
    const string PICKUP = "Pickup";

    string currentAnimation;

    CustomActions input;

    NavMeshAgent agent;
    Animator animator;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickEffect;
    [SerializeField] LayerMask clickableLayers;

    float lookRotationSpeed = 8f;

    [Header("Attack")]
    [SerializeField] float attackSpeed = 1.5f;
    [SerializeField] float attackDelay = 0.3f;
    [SerializeField] float attackDistance = 1.5f;
    [SerializeField] int attackDamage = 1;
    [SerializeField] ParticleSystem hitEffect;

    bool playerBusy = false;
    Interactable target;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        input = new CustomActions();
        AssignInputs();
    }

    void AssignInputs()
    {
        input.Main.Move.performed += TapInteraction => ClickToMove();
        input.Touch.TouchPress.performed += TapInteraction => TouchToMove();
    }

    void ClickToMove()
    {
     
            RaycastHit hit;


            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
            {

                {
                    agent.destination = hit.point;
                }

            }
        
    }
    void TouchToMove()
    {
       
        
            RaycastHit hit;


            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit, 100, clickableLayers))
            {

                agent.destination = hit.point;

            }

        
    }


    void OnEnable()
    { input.Enable(); }

    void OnDisable()
    { input.Disable(); }

    void Update()
    {
        FollowTarget();
        FaceTarget();
        SetAnimations();
    }

    void FollowTarget()
    {
        if (target == null) return;

        if (Vector3.Distance(target.transform.position, transform.position) <= attackDistance)
        { ReachDistance(); }
        else
        { agent.SetDestination(target.transform.position); }
    }

    void FaceTarget()
    {
        if (agent.destination == transform.position) return;
        else
        {

            Vector3 facing = Vector3.zero;
            if (target != null)
            { facing = target.transform.position; }
            else
            { facing = agent.destination; }

            Vector3 direction = (facing - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
        }
    }

    void ReachDistance()
    {
        agent.SetDestination(transform.position);

        if (playerBusy) return;

        playerBusy = true;

        switch (target.interactionType)
        {
            case InteractableType.NPC:

                animator.Play(ATTACK);

                Invoke(nameof(SendAttack), attackDelay);
                Invoke(nameof(ResetBusyState), attackSpeed);
                break;
            case InteractableType.Item:

                target.InteractWithItem();
                target = null;

                Invoke(nameof(ResetBusyState), 0.5f);
                break;
        }
    }

    void SendAttack()
    {
        if (target == null) return;

        if (target.myActor.currentHealth <= 0)
        { target = null; return; }

        Instantiate(hitEffect, target.transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        target.GetComponent<Actor>().TakeDamage(attackDamage);
    }

    void ResetBusyState()
    {
        playerBusy = false;
        SetAnimations();
    }

    void SetAnimations()
    {
        if (agent.velocity == Vector3.zero)
        {
            animator.SetBool("isRunning", false);
            animator.SetBool("isJumping", false);
        }
        if (agent.velocity != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
            animator.SetBool("isJumping", false);
        }
    }
}
