using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainBrick"))
        {
            other.transform.position = new Vector3(0, 1.5f, 0);
        }
        if (other.CompareTag("CloneBrick"))
        {
            Destroy(other.GetComponent<Rigidbody>());
            other.transform.Translate(Vector3.down * 5);
        }
    }
}
