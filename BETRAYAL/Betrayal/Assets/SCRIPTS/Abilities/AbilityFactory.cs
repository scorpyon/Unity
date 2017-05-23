using Assets.SCRIPTS.Races;
using Assets.SCRIPTS.Roles;

namespace Assets.SCRIPTS.Abilities
{
    public class AbilityFactory
    {
        public Ability GenerateDefaults(Race race, Role role)
        {
            var strength = Generate_Strength(race);
            var dexterity = Generate_Dexterity(race);
            var agility = Generate_Agility(race);
            var endurance = Generate_Endurance(race);
            var mysticism = Generate_Mysticism(race);
            var will = Generate_Will(race);
            var perception = Generate_Perception(race);

            strength += ModifyForRole_Strength(role);
            dexterity += ModifyForRole_Dexterity(role);
            agility += ModifyForRole_Agility(role);
            endurance += ModifyForRole_Endurance(role);
            mysticism += ModifyForRole_Mysticism(role);
            will += ModifyForRole_Will(role);
            perception += ModifyForRole_Perception(role);

            return new Ability(strength,dexterity,agility,endurance,mysticism,will,perception);
        }

        private int ModifyForRole_Strength(Role role)
        {
            switch (role)
            {
                case Role.Knight: return 4;
            }
            return 0;
        }

        private int ModifyForRole_Dexterity(Role role)
        {
            switch (role)
            {
                case Role.Knight: return 1;
            }
            return 0;
        }

        private int ModifyForRole_Agility(Role role)
        {
            switch (role)
            {
                case Role.Knight: return -2;
            }
            return 0;
        }

        private int ModifyForRole_Endurance(Role role)
        {
            switch (role)
            {
                case Role.Knight: return 4;
            }
            return 0;
        }

        private int ModifyForRole_Mysticism(Role role)
        {
            switch (role)
            {
                case Role.Knight: return 0;
            }
            return 0;
        }

        private int ModifyForRole_Will(Role role)
        {
            switch (role)
            {
                case Role.Knight: return 6;
            }
            return 0;
        }

        private int ModifyForRole_Perception(Role role)
        {
            switch (role)
            {
                case Role.Knight: return 2;
            }
            return 0;
        }


        private int Generate_Strength(Race race)
        {
            switch (race)
            {
                case Race.Human: return 10;
            }
            return 10;
        }

        private int Generate_Dexterity(Race race)
        {
            switch (race)
            {
                case Race.Human: return 10;
            }
            return 10;
        }

        private int Generate_Agility(Race race)
        {
            switch (race)
            {
                case Race.Human: return 10;
            }
            return 10;
        }

        private int Generate_Endurance(Race race)
        {
            switch (race)
            {
                case Race.Human: return 10;
            }
            return 10;
        }

        private int Generate_Mysticism(Race race)
        {
            switch (race)
            {
                case Race.Human: return 10;
            }
            return 10;
        }

        private int Generate_Will(Race race)
        {
            switch (race)
            {
                case Race.Human: return 10;
            }
            return 10;
        }

        private int Generate_Perception(Race race)
        {
            switch (race)
            {
                case Race.Human: return 10;
            }
            return 10;
        }

    }
}
