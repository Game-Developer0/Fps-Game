using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.Universal;

public class RayShooter : MonoBehaviour
{
    Camera camera;
    public GameObject gun;
    public GameObject impactEffect;
    public GameObject bloodParticale;
    // Start is called before the first frame update
    void Start()
    {
        camera = GetComponent<Camera>();
        
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
            if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                GameObject hitObject = hit.transform.gameObject;
                if (hit.collider.CompareTag("Enemy")){
                    GameObject spawn_particale=Instantiate(bloodParticale, hit.point, Quaternion.LookRotation(hit.normal));
                    Destroy(spawn_particale,3f);
                }
                GameObject spawn_smoke=Instantiate(impactEffect,hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(spawn_smoke, 2f);
                Debug.Log(hit.transform.position);
                ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
                if (target != null)
                {
                    target.ReactToHit();
                    Messenger.Broadcast(GameEvent.ENEMY_HIT);
                }
                
            }
        }
        
    }
   
    IEnumerator SphereIndicator(Vector3 pos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = pos;
        yield return new WaitForSeconds(2);
        Destroy(sphere);
    }
    private void OnGUI()
    {
        int size = 12;
        float posX = camera.pixelWidth / 2 - size / 4;
        float posY = camera.pixelHeight / 2 - size / 2;
        GUI.contentColor = Color.black;
        GUI.Label(new Rect(posX, posY, size, size), "*");
        GUI.contentColor = Color.white;
    }
}