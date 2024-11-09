using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int DamageScore = -1;
    [SerializeField] private Animator animator;
    public Vector2 AttackForce;
    private Vector2 TFpos = new Vector2(0, -1);
    private EnemyMovement movecomp;

    private LevelManager levelManager;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        movecomp = GetComponent<EnemyMovement>();
    }
    public void SetLevelManager(LevelManager levelManager)
    {
        this.levelManager = levelManager;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out var player))
        {
            var plAnimator = collision.GetComponent<Animator>();
            var plBody = collision.GetComponent<Rigidbody2D>();
            plBody.AddForce(Vector2.left * AttackForce.x * 500);
            plAnimator.SetTrigger("Hurt");
            animator.SetTrigger("Attack");
            levelManager.UpdateScore(DamageScore);
            Debug.Log("You have been bitten, -1 health points");
        }
        if (collision.TryGetComponent<BalalaikaFlag>(out var bal))
        {
            GameObject tplayer = bal.gameObject.transform.parent.gameObject;
            var InpSys = tplayer.GetComponent<InputSystemController>();
            var tAnimator = tplayer.GetComponent<Animator>();
            InpSys.EnemyNearCheck = true;
            Debug.Log("Balalaika collider has been intersected!");
            if (InpSys.EnemyNeutralized)
            {
                tAnimator.SetTrigger("Play");
                InpSys.EnemyNearCheck = false;
                InpSys.EnemyNeutralized = false;
                StartCoroutine(OnNeutralized());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject tplayer = collision.gameObject.transform.parent.gameObject;
        var InpSys = tplayer.GetComponent<InputSystemController>();
        InpSys.EnemyNearCheck = false;
    }
    private IEnumerator OnNeutralized()
    {
        animator.SetTrigger("Stopped");
        movecomp.headColliderLeft.gameObject.SetActive(false);
        movecomp.headColliderRight.gameObject.SetActive(false);
        movecomp.enabled = false;
        yield return new WaitForSeconds(1);
        animator.SetBool("Defeated", true);
        yield return new WaitForSeconds(0.5f);
        movecomp.enabled = true;
        movecomp.OnDefeat();
    }
}
