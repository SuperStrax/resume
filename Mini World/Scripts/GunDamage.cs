
using UnityEngine;

public class GunDamage : MonoBehaviour
{
    public Camera mainCam;
    public LayerMask enemyLayer;
    void Start()
    {
        mainCam = Camera.main;
    }

    
    void Update()
    {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100f, enemyLayer) && Input.GetMouseButtonDown(0))
        {
            if (hit.transform.gameObject.CompareTag("Enemy"))
            {
                hit.transform.gameObject.GetComponent<EnemyHealth>().takeDamage(10f);
            }
        }
    }
}
