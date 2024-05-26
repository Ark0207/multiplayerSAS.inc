using UnityEngine;
using UnityEngine.SceneManagement;

public class playercontrollerA : MonoBehaviour
{
    [Header("Base setupchik")]
    public float walkspeed = 5f;
    public float runningspeed = 10f;
    public float jumpspeed = 20f;
    public float gravity = 9.8f;
    public float lookspeed = 3.6f;
    public float lookxlimit = 70f;
    public float Health = 3f;
    //public float lookylimit = 80f;

    CharacterController characterController;
    Vector3 movedirection = Vector3.zero;
    float rotationX = 0;

    [HideInInspector]
    public bool canmove = true;

    [SerializeField]
    private float cameraYoffset = 0.4f;
    private Camera playercamera;

    private Alteruna.Avatar _avatar;
    // Start is called before the first frame update
    void Start()
    {
        _avatar = GetComponent<Alteruna.Avatar>();
        if (!_avatar.IsMe)
            return;
        characterController = GetComponent <CharacterController>();
        playercamera = Camera.main;
        playercamera.transform.position = new Vector3(transform.position.x, transform.position.y + cameraYoffset, transform.position.z);
        playercamera.transform.SetParent(transform);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
}

// Update is called once per frame
void Update()
    {
        if (!_avatar.IsMe)
            return;
        bool isRunning = false;
        isRunning = Input.GetKey(KeyCode.LeftShift);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
            Vector3 right = transform.TransformDirection(Vector3.right);

        float curspeedX = canmove ? (isRunning ? runningspeed : walkspeed) * Input.GetAxis("Vertical") : 0;
        float curspeedY = canmove ? (isRunning ? runningspeed : walkspeed) * Input.GetAxis("Horizontal") : 0;
        float movementDirectionY = movedirection.y;
        movedirection = (forward * curspeedX) + (right * curspeedY);

        if(Input.GetButton("Jump") && canmove && characterController.isGrounded)
        {
            movedirection.y = jumpspeed;
        }
        else
        {
            movedirection.y = movementDirectionY;
        }
      
        if(!characterController.isGrounded)
        {
            movedirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(movedirection * Time.deltaTime);
         
        if(canmove && playercamera != null)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookspeed;
            rotationX = Mathf.Clamp(rotationX, -lookxlimit, lookxlimit);
            playercamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookspeed, 0);
        }
    
    
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag=="buster")
        {
            Destroy(hit.gameObject);
            Debug.Log("Collision detected with " + hit.gameObject.name);
            jumpspeed += 10;
        }
        else if (hit.gameObject.tag == "Wall")
        {
            Destroy(hit.gameObject);
            Debug.Log("Collision detected with " + hit.gameObject.name);
            jumpspeed -= 10;
        }
        else if (hit.gameObject.tag == "damage")
        {
            Health -= 1f;
            if (Health < 0)
            {
                Health = 0;
                SceneManager.LoadScene(0);
            }
        }
    
    }
      



}
   

