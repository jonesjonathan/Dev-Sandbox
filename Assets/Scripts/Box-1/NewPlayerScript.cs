using UnityEngine;
using System.Collections;

public class NewPlayerScript : MonoBehaviour
{
    public float speed;
    public float sensitivity;

    private void Rotation()
    {
        Vector3 rotate = new Vector3(0, Input.GetAxis("Mouse X"), 0) * Time.deltaTime * sensitivity;
        transform.Rotate(rotate);
    }

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float forward = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        float sideways = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        Rotation();
        transform.Translate(sideways, 0, forward);

        if(Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
