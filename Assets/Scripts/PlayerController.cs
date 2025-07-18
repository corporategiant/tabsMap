using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    const string IDLE = "Idle";
    const string RUN = "Run";

    CustomActions input;

    NavMeshAgent agent;

    Animator animator;

    [Header("Movement")]
    [SerializeField] ParticleSystem clickeffect;
    [SerializeField] LayerMask clickableLayers;

    float lookRotationSpeed = 8f;
    public bool excludeTouch;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        input = new CustomActions();
        AssignInputs();

    }

    void AssignInputs()
    {
        input.Main.Move.performed += ctx => ClicktoMove();
        input.Touch.TouchPress.performed += ctx => TouchtoMove();
    }

    void ClicktoMove()
    {
        RaycastHit hit;

 
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100, clickableLayers))
            {

                {
                    agent.destination = hit.point;
                }
            
        }

    }
    void TouchtoMove()
    {
        RaycastHit hit;

  
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.GetTouch(0).position), out hit, 100, clickableLayers))
            {

                agent.destination = hit.point;

            }
        

    }

    void OnEnable()
    {
        input.Enable();
    }

    void OnDisable()
    {
        input.Disable();
    }

    void Update()
    {
        FaceTarget();
        SetAnimations();

    }

    void FaceTarget()
 {
    if (agent.velocity != Vector3.zero)
    {
        Vector3 direction = (agent.destination - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * lookRotationSpeed);
    }
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
