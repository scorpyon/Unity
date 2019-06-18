using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class FryingPanControl : MonoBehaviour
    {
        private List<GameObject> ObjectsInPan { get; set; }
        public bool IsOnStove = false;

        // Start is called before the first frame update

        void Start()
        {
            InvokeRepeating("CookFood", 0, 1.0f);
        }

        // Update is called once per frame

        void CookFood()
        {
            if (IsOnStove)
            {
                foreach (var objectInPan in ObjectsInPan)
                {
                    if (objectInPan.tag == "burger_raw" || objectInPan.tag == "burger_cooked")
                    {
                        ProgressBurgerState(objectInPan);
                    }
                }
            }
        }

        private void ProgressBurgerState(GameObject objectInPan)
        {
            var burgerState = objectInPan.GetComponent<BurgerState>();
            var burgerTrans = objectInPan.transform;
            var nextObject = burgerState.NextBurgerState;

            if (objectInPan.tag == "burger_raw")
            {
                burgerState.CookedAmount += 10;
            }
            else if (objectInPan.tag == "burger_cooked")
            {
                burgerState.CookedAmount += 25;
            }

            if (burgerState.CookedAmount < 100) return;

            ObjectsInPan.Remove(objectInPan);
            Destroy(objectInPan);
            Instantiate(nextObject, burgerTrans);
        }


        void OnTriggerEnter(Collider other)
        {
            ObjectsInPan.Add(other.gameObject);
        }

        void OnTriggerExit(Collider other)
        {
            if (ObjectsInPan.Contains(other.gameObject))
            {
                ObjectsInPan.Remove(other.gameObject);
            }
        }

    }
}
