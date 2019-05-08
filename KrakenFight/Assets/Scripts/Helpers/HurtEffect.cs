using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtEffect : MonoBehaviour
{
    private SpriteRenderer image;
    [SerializeField] private float hurtTime;
    [SerializeField] private Color hurtColor;

    private bool hurting;
    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
    }
    public void HurtEffectCallback()
    {
        if (!hurting)
        {
            StartCoroutine("HurtEffectRoutine");
        }
    }

    public IEnumerator HurtEffectRoutine()
    {
        hurting = true;
        Color originalColor = image.color;
        image.color = hurtColor;
        yield return new WaitForSeconds(hurtTime);
        image.color = originalColor;
        hurting = false;
    }
}
