using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class CharController : MonoBehaviour
{
    public PlayerInput input;
    public SoundManager sound;

    private float movementSpeed;
    public float movementSpeedBase;
    public int facing;
    public bool isAttacking;

    public UnityEvent ThrowAttackEvent;
    public UnityEvent ThrowAltAttackEvent;

    private Rigidbody2D RB;
    private Animator anim;

    // Start is called before the first frame update
    void Awake()
    {
        movementSpeed = movementSpeedBase;
        RB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(input.GetXAxis, 0, input.GetYAxis);
        facing = CalculateFacing(movement, facing);
        Vector3 projectedMovement = new Vector3(movement.x, movement.z + movement.y, movement.z);
        RB.MovePosition(this.transform.position + projectedMovement * movementSpeed * Time.fixedDeltaTime);
        this.transform.rotation = (Quaternion.Euler(0, facing, 0));

        if (!isAttacking && input.IsAttackingPressed)
        {
            isAttacking = true;
            ThrowAttackEvent?.Invoke();
            ThrowAttack();
            sound.PlayPlayerAttack();
        }
        if (!isAttacking && input.IsAltAttackingPressed)
        {
            isAttacking = true;
            ThrowAltAttackEvent?.Invoke();
            ThrowAltAttack();
            sound.PlayPlayerAltAttack();
        }
        if (!isAttacking && input.IsUsingPressed)
        {
            isAttacking = true;
            ThrowAltAttackEvent?.Invoke();
            ThrowUse();
            sound.PlayPlayerUse();
        }
    }

    public void ThrowAttack()
    {
        Debug.Log("Attack");
    }
    public void ThrowAltAttack()
    {
        Debug.Log("Alt Attack");
    }
    public void ThrowUse()
    {
        Debug.Log("Use");
    }

    private int CalculateFacing(Vector3 movement, int oldFacing)
    {
        if (movement.x < 0)
        {
            return 180;
        }
        else if (movement.x > 0)
        {
            return 0;
        }
        return oldFacing;
    }
}
