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
        Vector3 start = cameraTransform.position + cameraTransform.right * 0.1f;
        Vector3 end = cameraTransform.position + cameraTransform.forward * 100;

        GameObject resource = Resources.Load("beam") as GameObject;
        BeamManager beam = resource.GetComponent<BeamManager>();
        beam.start = start;
        beam.end = end;

        Instantiate(resource);
    }
}
