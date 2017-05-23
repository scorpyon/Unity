using Assets.SCRIPTS.GameManager;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

namespace Assets.SCRIPTS
{
    public class PlayerMove : NetworkBehaviour
    {
        public Game Game;

        public float shootDistance = 10f;
        public float shootRate = .5f;
        //public ShootingScript ShootingScript;

        private Animator _anim;
        private NavMeshAgent _navMeshAgent;
        private Transform _target;
        private Ray _shootRay;
        private RaycastHit _shootHit;
        private bool _walking;
        private bool _enemyClicked;
        private float _nextFire;


        void Awake()
        {
            _anim = GetComponent<Animator>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        void Start()
        {
            Game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
        }
    
        //public GameObject BulletPrefab;
    
        // Update is called once per frame
        void Update()
        {
            var ray = UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Input.GetButtonDown("Fire1"))
            {
                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.CompareTag("Enemy"))
                    {
                        _target = hit.transform;
                        //_enemyClicked = true;
                    }
                    else if (hit.collider.CompareTag("Hero"))
                    {
                        _target = hit.transform;
                        if (_target == gameObject.transform)
                        {
                            Game.SelectHero(gameObject);
                        }
                    }
                    else
                    {
                        // If it's not the right hero, do nothing!
                        if (gameObject != Game.CurrentHero) return;
                        _walking = true;
                        _enemyClicked = false;
                        _navMeshAgent.destination = hit.point;
                        _navMeshAgent.isStopped = false;
                    }
                }
            }
            if (_enemyClicked)
            {
                //MoveAndShoot();
            }
        }


        private void MoveAndShoot()
        {
            if (_target == null) return;

            _navMeshAgent.destination = _target.position;
            if (_navMeshAgent.remainingDistance >= shootDistance)
            {
                _navMeshAgent.isStopped = false;
                _walking = true;
            }
            if (_navMeshAgent.remainingDistance <= shootDistance)
            {
                transform.LookAt(_target);
                var directionToShoot = _target.transform.position - transform.position;
                if (Time.time > _nextFire)
                {
                    _nextFire = Time.time + shootRate;
                    //ShootingScript.Shoot(directionToShoot);
                }
            }
        }

        //[Command]
        //void CmdFire()
        //{
        //    // This [Command] code is run on the server!

        //    // create the bullet object locally
        //    var bullet = (GameObject)Instantiate(
        //         BulletPrefab,
        //         transform.position - transform.forward,
        //         Quaternion.identity);

        //    bullet.GetComponent<Rigidbody>().velocity = -transform.forward * 4;

        //    // spawn the bullet on the clients
        //    NetworkServer.Spawn(bullet);

        //    // when the bullet is destroyed on the server it will automaticaly be destroyed on clients
        //    Destroy(bullet, 2.0f);
        //}

        public void Select()
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}

