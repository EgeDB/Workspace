using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    [SerializeField] private Character controller;
    private Animator anim;
    

    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }

    private void Update()
    {
      anim.SetBool("IsWalking",controller.IsWalking());
      anim.SetBool("IsAttaking", controller.IsAttaking());
    }
}
