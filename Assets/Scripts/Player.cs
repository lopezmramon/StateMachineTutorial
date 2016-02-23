using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    GameObject groundChecker;
    public bool grounded;
    public float moveSpeed, jumpSpeed;
    Rigidbody2D r2d;
    Animator anim;
    public LayerMask groundLayer;

    public enum CharacterState
    {
        Idle,
        Walk,
        Run,
        Jump,
        Fall,
        Attack,
        Death,


    }
    public CharacterState currentCharacterState;



	void Start () {
        r2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        groundChecker = GameObject.Find("GroundChecker");
        ChangeState(CharacterState.Idle);

	}
	
    void ChangeState(CharacterState newState)
    {
        currentCharacterState = newState;
        StartCoroutine(newState.ToString() + "State");

    }
	void Update ()
    {
        if (Input.GetKey(KeyCode.D) & grounded & currentCharacterState != CharacterState.Run)
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            ChangeState(CharacterState.Walk);

        }
        if (Input.GetKey(KeyCode.D) & Input.GetKey(KeyCode.LeftShift) & grounded)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 2 * moveSpeed);
            ChangeState(CharacterState.Run);

        }

        if (grounded & Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
            ChangeState(CharacterState.Jump);
        }

        if (grounded & Input.GetKeyDown(KeyCode.O))
        {
            ChangeState(CharacterState.Attack);
        }

        if (r2d.velocity.y < 0)
        {
            ChangeState(CharacterState.Fall);
        }


        if (Input.GetKeyUp(KeyCode.D) & currentCharacterState == CharacterState.Walk)
        {
            ChangeState(CharacterState.Idle);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift) &  currentCharacterState == CharacterState.Run)
        {
            ChangeState(CharacterState.Idle);
        }
    }


    void FixedUpdate()
    {


        grounded = Physics2D.OverlapCircle(groundChecker.transform.position, 0.2f, groundLayer);
    }


    //CharacterStates---------------------***

    IEnumerator IdleState()
    {

        while (currentCharacterState == CharacterState.Idle)
        {
            anim.SetInteger("State", 0);
            yield return null;
        }
    }
    IEnumerator WalkState()
    {

        while (currentCharacterState == CharacterState.Walk)
        {
            anim.SetInteger("State", 1);
            yield return null;
        }
    }
    IEnumerator RunState()
    {

        while (currentCharacterState == CharacterState.Run)
        {
            anim.SetInteger("State", 2);
            yield return null;
        }
    }
    IEnumerator JumpState()
    {

        while (currentCharacterState == CharacterState.Jump)
        {
            anim.SetInteger("State", 3);
            yield return null;
        }
    }
    IEnumerator FallState()
    {

        while (currentCharacterState == CharacterState.Fall)
        {
            anim.SetInteger("State", 4);
            if (grounded) ChangeState(CharacterState.Idle);
            yield return null;
        }
    }
    IEnumerator AttackState()
    {

        while (currentCharacterState == CharacterState.Attack)
        {
            anim.SetInteger("State",5 );
            yield return new WaitForSeconds(0.2f);
            ChangeState(CharacterState.Idle);
        }
    }
    IEnumerator DeathState()
    {

        while (currentCharacterState == CharacterState.Death)
        {
            anim.SetInteger("State", 6);
            yield return null;
        }
    }
}
