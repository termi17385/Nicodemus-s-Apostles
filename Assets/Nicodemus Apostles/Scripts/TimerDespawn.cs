using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerDespawn : MonoBehaviour
{
    
        public float timeDelay;      //time waited before platforms get destroyed
        public GameObject oldObject;  //object being destroyed, is a prefab


        private float timeCurrent = 0.0f;  //variable to keep track of time since last object was destroyed, starts off as 0
                                           // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            timeCurrent += Time.deltaTime;          //game runs in real time, so add the time to the var keeping track of time every frame

            if (timeCurrent > timeDelay)            //only activates after the set time delay
            {
                Destroy(this.oldObject);         //call to destroy the platform created after so many seconds
                        //call to destroy the platform created after so many seconds
                timeCurrent = timeCurrent - timeDelay;      //resets the timer
            }

        }
 
}
