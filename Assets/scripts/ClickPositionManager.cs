using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionManager : MonoBehaviour {


    public LayerMask clickMask;

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private bool useGravity = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            Vector3 clickPosition = -Vector3.one;

            //PROCESSING
            clickPosition = Camera.main.ScreenToViewportPoint(Input.mousePosition + new Vector3 (0,0,5f));

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit,100f, clickMask)) {
                clickPosition = hit.point;
            }

            Debug.Log(clickPosition);
            CmdFire(clickPosition);
        }



	}

    void CmdFire(Vector3 position)
    {
        Quaternion rotation = new Quaternion(0f, 0f, 0f, 0f);
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            position,
            rotation);
    }

    public void switchSpawnable(string name){
        bulletPrefab = (GameObject)Resources.Load("prefabs/" + name, typeof(GameObject));
        bulletPrefab.GetComponent<Rigidbody>().useGravity = useGravity;
    }

    public void switchGravity()
    {
        useGravity = !useGravity;
        bulletPrefab.GetComponent<Rigidbody>().useGravity = useGravity;
        //bulletPrefab = (GameObject)Resources.Load(bulletPrefab.name, typeof(GameObject));
    }
}
