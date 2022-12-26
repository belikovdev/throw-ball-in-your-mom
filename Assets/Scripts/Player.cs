using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator animator;
    public Transform throwableParent;
    public ThrowableObject throwableObject;
    public float fireRate = 1f;
    private float nextThrowTime = 0f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time < nextThrowTime)
                return;
            
            nextThrowTime = Time.time + 1f / fireRate;
            
            var ball = Instantiate(throwableObject, throwableParent, false);
            ball.transform.localPosition = Vector3.zero;
            animator.SetTrigger("Throw");
            animator.speed = 2f;
            StartCoroutine(ThrowObject(ball));
        }
    }

    IEnumerator ThrowObject(ThrowableObject obj)
    {
        yield return new WaitForSeconds(1f/animator.speed);
        obj.transform.parent = null;
        obj.Throw();
    }
}
