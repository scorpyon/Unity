using Assets.SCRIPTS.GameManager;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using UnityEngine;

namespace Assets.SCRIPTS.Camera
{
    public class CameraMove : MonoBehaviour
    {
        public Game Game;
        public bool FreeCamera = false;

        // Use this for initialization
        void Start ()
        {
            Game = GameObject.FindGameObjectWithTag("GameController").GetComponent<Game>();
        }
	
        // Update is called once per frame
        void Update ()
        {
            if (Game.CurrentHero == null) return;
            UnityEngine.Camera.main.transform.position = Vector3.Lerp(UnityEngine.Camera.main.transform.position, new Vector3(Game.CurrentHero.transform.position.x, Game.CurrentHero.transform.position.y + 5, Game.CurrentHero.transform.position.z - 6), 0.04f);
        }
    }
}
