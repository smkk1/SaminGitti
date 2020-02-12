﻿using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
public class MenuTextAnimation : MonoBehaviour, IPointerEnterHandler
{

    public void OnPointerEnter(PointerEventData eventData)
    {
        Animator animator = GetComponent<Animator>();
        if (animator != null)
        {
            if (!animator.GetCurrentAnimatorStateInfo(0).IsName("MenuButtonAnimation"))
            {
                animator.Play("MenuButtonAnimation");
                FindObjectOfType<AudioManager>().Play("Click");
            }
        }
    }

}
