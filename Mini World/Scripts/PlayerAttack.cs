
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public float damage = 20f;
    private bool attack;
    private Collider monster;
    private Animator anim;
    private AudioSource audioS;



    private void Start()
    {
        anim = transform.parent.GetComponent<Animator>();
        audioS = GetComponent<AudioSource>();
    }

    private void Update()
    {


        if (Input.GetMouseButtonDown(0) && attack && monster != null && !PlayerHealth.death)
        {
            monster.GetComponent<EnemyHealth>().takeDamage(damage);
            anim.SetTrigger("Attack");
            audioS.Play();
        }
            
          
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            attack = true;
            monster = other;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            attack = false;
            monster = null;
        }
    }
}
