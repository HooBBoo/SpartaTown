using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public RuntimeAnimatorController[] catAnimators;
    private Animator playerAnimator;

    private void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void SelectCat(int catIndex)
    {
        playerAnimator.runtimeAnimatorController = catAnimators[catIndex];
    }
}
