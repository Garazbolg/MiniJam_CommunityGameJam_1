using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string xAxis;
    public string yAxis;
    public string attackButton;
    public string altAttackButton;
    public string useButton;

    public float GetXAxis
    {
        get { return Input.GetAxisRaw(xAxis); }
    }
    public float GetYAxis
    {
        get { return Input.GetAxisRaw(yAxis); }
    }
    public bool IsAttackingPressed
    {
        get { return Input.GetButtonDown(attackButton); }
    }
    public bool IsAltAttackingPressed
    {
        get { return Input.GetButtonDown(altAttackButton); }
    }
    public bool IsUsingPressed
    {
        get { return Input.GetButtonDown(useButton); }
    }
}
