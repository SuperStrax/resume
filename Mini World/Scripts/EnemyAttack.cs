
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAttack : MonoBehaviour
{
    private NavMeshAgent agent;
    public float damage = 5f;
    private Coroutine dmg;
    private Animator anim;
    public GameObject damageButton, image;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(agent.enabled)
                agent.SetDestination(other.transform.position);
        }

        if (other.CompareTag("Attack"))
        {
            if(dmg == null)
            {
                dmg = StartCoroutine(setDamage(other));
                anim.SetBool("isAttack", true);
            }
            
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<MoveAgents>().setNewPath();
        }
        if (other.CompareTag("Attack"))
        {
            StopCoroutine(dmg);
            dmg = null;
            anim.SetBool("isAttack", false);
        }
    }

    IEnumerator setDamage(Collider other)
    {
        while (true)
        {
            if(agent.enabled)
            other.transform.parent.GetComponent<PlayerHealth>().takeDamage(damage);


            yield return new WaitForSeconds(0.5f);
        }
    }

    public void onClickDamage()
    {
        StartCoroutine(dontDamage());
    }

    IEnumerator dontDamage()
    {
        image.SetActive(false);
        damage = 0f;
        yield return new WaitForSeconds(5);
        damage = 5f;
        damageButton.SetActive(false);
    }
}
