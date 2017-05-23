using Assets.SCRIPTS.Races;
using UnityEngine;

namespace Assets.SCRIPTS.Heroes
{
    public class SpawnHeroes : MonoBehaviour
    {

        public HeroFactory HeroFactory;

        // Use this for initialization
        void Start () {

            HeroFactory.Create_Knight("Sir Jury", Race.Human, new Vector3(1, 0, 1), Quaternion.identity);
            HeroFactory.Create_Knight("Sir Blah", Race.Human, new Vector3(2, 0, 0), Quaternion.identity);
            HeroFactory.Create_Knight("Sir Blobby", Race.Human, new Vector3(4, 0, -1), Quaternion.identity);
            HeroFactory.Create_Knight("Sir Ten", Race.Human, new Vector3(-3, 0, 0), Quaternion.identity);
            HeroFactory.Create_Knight("Sir Iuss", Race.Human, new Vector3(-1, 0, -2), Quaternion.identity);

        }   

        // Update is called once per frame
        void Update () {
		
        }
    }
}
