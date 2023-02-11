using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "StaticObject") {
            //lose rats function???
            Debug.Log("???");
            this.GetComponent<RatsCount>().ChangeRatCount(other.gameObject.GetComponent<RatChangeObject>().GetRatChangeAmount());
            Destroy(other.gameObject);
        }
    }
}
