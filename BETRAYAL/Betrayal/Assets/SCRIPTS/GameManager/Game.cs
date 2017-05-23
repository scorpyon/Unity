using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Assets.SCRIPTS.GameManager
{
    public class Game : MonoBehaviour {

        public Collection<GameObject> Heroes = new Collection<GameObject>();
        public GameObject CurrentHero;
        public Transform CameraPosition;

        // Use this for initialization
        void Start ()
        {
            FindAHero();
        }

        private void FindAHero()
        {
            var foundHeroes = GameObject.FindGameObjectsWithTag("Hero");
            foreach (var foundHero in foundHeroes)
            {
                Heroes.Add(foundHero);
            }
            if (Heroes.Count > 0) CurrentHero = Heroes.FirstOrDefault();
        }

        // Update is called once per frame
        void Update () {
            if (Heroes == null) return;
            if (CurrentHero == null)
            {
                //Debug.Log("Searching for a hero...");
                FindAHero();
                return;
            }
            // Select a Hero with the F-Keys
            var heroSelected = 0;
            if (Input.GetKeyDown(KeyCode.F1)) heroSelected = 1;
            if (Input.GetKeyDown(KeyCode.F2)) heroSelected = 2;
            if (Input.GetKeyDown(KeyCode.F3)) heroSelected = 3;
            if (Input.GetKeyDown(KeyCode.F4)) heroSelected = 4;
            if (Input.GetKeyDown(KeyCode.F5)) heroSelected = 5;
            if (heroSelected > 0)
            {
                SelectHero(Heroes[heroSelected - 1]);
            }
        }

        public void SelectHero(GameObject hero)
        {
            ResetHeroSelection();
            CurrentHero = hero;
            CurrentHero.GetComponent<MeshRenderer>().material.color = Color.red;
        }

        public void ResetHeroSelection()
        {
            foreach (var hero in Heroes)
            {
                hero.GetComponent<MeshRenderer>().material.color = Color.white;
            }
        }
    }
}
