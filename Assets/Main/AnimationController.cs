using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void AnimatorState(bool isGrounded, float speed)
    {
        _animator.SetBool("Grounded", isGrounded);
        _animator.SetFloat("Speed", speed);
    }

    public void HadleJump()
    {
        _animator.SetTrigger("Jump");
    }
    public void OnLand()
    {
        Debug.Log("Landed! GameObject: " + gameObject.name);
    }
}
