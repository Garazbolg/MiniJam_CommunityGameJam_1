using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HurtEffect : MonoBehaviour
{
    private SpriteRenderer image;
    [SerializeField] private float hurtTime;
    [SerializeField] private Color hurtColor;
    private void Awake()
    {
        image = GetComponent<SpriteRenderer>();
    }
    public void HurtEffectCallback()
    {
        StartCoroutine("HurtEffectRoutine");
    }

    public IEnumerator HurtEffectRoutine()
    {
        Color originalColor = image.color;
        image.color = hurtColor;
        yield return new WaitForSeconds(hurtTime);
        image.color = originalColor;
    }
}
