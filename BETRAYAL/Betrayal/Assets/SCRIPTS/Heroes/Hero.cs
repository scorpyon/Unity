using Assets.SCRIPTS.Abilities;
using Assets.SCRIPTS.Races;
using Assets.SCRIPTS.Roles;
using UnityEngine;

namespace Assets.SCRIPTS.Heroes
{
    public class Hero : MonoBehaviour {

        public string Name = "DEFAULT";
        public Race Race;
        public Ability Ability;
        public Role Role { get; set; }

        public void Initialize(string name, Race race, Role role)
        {
            Name = name;
            Race = race;
            Role = role;
            var abilityFactory = new AbilityFactory();
            Ability = abilityFactory.GenerateDefaults(Race,Role);
        }

        // Use this for initialization
        void Start () {
		    
        }
	
        // Update is called once per frame
        void Update () {
		
        }

    }
}
