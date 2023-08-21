using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Find : MonoBehaviour
{
    public GameObject brick;
    public List<GameObject> clones;
    public Vector3 cloneDirection = new Vector3(0, -.5f, 0);
    public GameObject cloneParent;
    private GameObject box;
    public float resizeSpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        cloneParent = Instantiate(new GameObject(), new Vector3(0, 25, 0), Quaternion.identity);
        box = GameObject.Find("Environment");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            box.transform.localScale = new Vector3(1, 1, box.transform.localScale.z * resizeSpeed);
        }
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            box.transform.localScale = new Vector3(1, 1, box.transform.localScale.z / resizeSpeed);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            brick = GameObject.Find("Brick");
        }
        if (Input.GetKeyDown(KeyCode.I) || Input.GetKey(KeyCode.K))
        {
            GameObject thisClone = Instantiate(brick,
                                                new Vector3(0, 1, 0),
                                                brick.transform.rotation);
            GameObject thatClone = Instantiate(brick,
                                                new Vector3(12.5f, 1, 0),
                                                brick.transform.rotation);
            GameObject thyClone = Instantiate(brick,
                                                new Vector3(-12.5f, 1, 0),
                                                brick.transform.rotation);
            thisClone.transform.parent = cloneParent.transform;
            thatClone.transform.parent = cloneParent.transform;
            thyClone.transform.parent = cloneParent.transform;
            thisClone.tag = "CloneBrick";
            thatClone.tag = "CloneBrick";
            thyClone.tag = "CloneBrick";
            clones.Add(thisClone);
            clones.Add(thatClone);
            clones.Add(thyClone);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            foreach (GameObject clone in clones)
            {
                Rigidbody tempRb = clone.GetComponent<Rigidbody>();
                tempRb.useGravity = true;
            }
            brick.GetComponent<Rigidbody>().useGravity = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            foreach (GameObject clone in clones)
            {
                Rigidbody tempRb = clone.GetComponent<Rigidbody>();
                tempRb.useGravity = false;
            }
            brick.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
