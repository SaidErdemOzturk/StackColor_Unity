using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : Singleton<AnimationManager>
{
    private PlayerManager playerManager;
    private Animator anim;

    private void Start()
    {
        playerManager = PlayerManager.GetInstance();
        anim = playerManager.GetAnim();
    }

    public void KickAnim()
    {
        anim.SetTrigger("kick");
    }

    public void SetSpeedAnim(float speed)
    {
        anim.SetFloat("runSpeed",speed);
    }


    public void PushAnim()
    {
        anim.SetBool("isStarted",true);
    }
}
