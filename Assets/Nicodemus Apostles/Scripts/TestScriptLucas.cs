using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScriptLucas : MonoBehaviour
{

    public class PlatformGeneration : MonoBehaviour
    {
        public GameObject thePlatform;          //platform object
        public Transform generationPoint;       //point at which new platforms spawn
        public float distanceBetween;           //distance between each platform being spawned

        private float platformWidth;            //how wide each platform actually is

        // Start is called before the first frame update
        void Start()
        {
            platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;  //defining the total width of the current platform
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.position.x < generationPoint.position.x)
            {
                transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

                Instantiate(thePlatform, transform.position, transform.rotation);   //spawn le new platform
            }
        }
    }
}
