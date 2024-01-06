using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayShooter : MonoBehaviour
{
    Camera camera;
    public GameObject gun;
    // Start is called before the first frame update
    void Start()
    {
        camera=GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
            Vector3 origion = new Vector3(camera.pixelWidth / 2, camera.pixelHeight / 2, 0);
            Ray ray = camera.ScreenPointToRay(origion);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                gun.transform.LookAt(hit.point);
            if (Input.GetMouseButtonDown(0)) { 
                GameObject hitObject = hit.transform.gameObject;
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if(target != null)
                {
                    target.ReactToHit();
                }
                else
                {
                    //StartCoroutine(SphereIndicator(hit.point));
                }
            }
        }
    }
    IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere=GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(2);
        Destroy(sphere);
    }
    private void OnGUI()
    {
        int size = 12;
        float posX=camera.pixelWidth/2-size/4;
        float posY=camera.pixelHeight/2-size/2;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(posX, posY, size, size), "*");
        GUI.contentColor = Color.white;
    }
}
