using UnityEngine;

namespace Assets.SCRIPTS
{
    public class ShootingScript : MonoBehaviour {

        // Use this for initialization
        void Start () {
		
        }
	
        // Update is called once per frame
        void Update () {
		
        }

        public void Shoot(Vector3 directionToShoot)
        {
            // Currently not implemented
        }

        void OnCollisionEnter(Collision collision)
        {
            var hit = collision.gameObject;
            var hitCombat = hit.GetComponent<CombatScript>();
            if (hitCombat != null)
            {
                hitCombat.TakeDamage(10);
                Destroy(gameObject);
            }
        }
    }
}
