using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    Transform cameraTransform;
    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            ShootBeam();
        }
    }

    private void ShootBeam() {
        Vector3 start = cameraTransform.position + cameraTransform.right * 0.01f;
        Vector3 end = cameraTransform.position + cameraTransform.forward * 100;

        RaycastHit hit;

        if(Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit)) {
            end = hit.point;
            if(hit.transform.tag == "teleporter") {
                CreateTeleporter(hit.point);
            }
        }
        GameObject resource = Resources.Load("beam") as GameObject;
        BeamManager beam = resource.GetComponent<BeamManager>();
        beam.start = start;
        beam.end = end;

        Instantiate(resource);
    }

    private void CreateTeleporter(Vector3 position) {
        GameObject teleporter = Resources.Load("teleporter") as GameObject;
        Instantiate(teleporter, position, Quaternion.identity);
    }
}
