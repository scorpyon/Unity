namespace Assets.SCRIPTS.Abilities
{
    public class Ability
    {
        public int Strength { get; private set; }
        public int Dexterity { get; private set; }
        public int Agility { get; private set; }
        public int Endurance { get; private set; }
        public int Mysticism { get; private set; }
        public int Will { get; private set; }
        public int Perception { get; private set; }

        public Ability(int strength, int dexterity, int agility, int endurance, int mysticism, int will, int perception)
        {
            Strength = strength;
            Dexterity = dexterity;
            Agility = agility;
            Endurance = endurance;
            Mysticism = mysticism;
            Will = will;
            Perception = perception;
        }

    }
}
