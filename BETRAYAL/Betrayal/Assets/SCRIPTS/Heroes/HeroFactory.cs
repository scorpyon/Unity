using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.SCRIPTS.Races;
using Assets.SCRIPTS.Roles;
using UnityEngine;

namespace Assets.SCRIPTS.Heroes
{
    public class HeroFactory : MonoBehaviour
    {
        protected static HeroFactory instance; // Needed
        public GameObject HeroPrefab;

        void Start()
        {
            instance = this;
        }

        public static Hero Create_Knight(string name, Race race, Vector3 position, Quaternion rotation)
        {
            var hero = Instantiate(instance.HeroPrefab, position, rotation).GetComponent<Hero>();
            hero.Initialize(name, race, Role.Knight);
            return hero;
        }
    }
}
