using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_Player : MonoBehaviour
{
    // 
    private Rigidbody _rb;

    #region Camera
    private Camera _cam;
    private CameraMovement _cm;
    private Vector3 camFwd;
    #endregion

    #region Movement
    [Range(1.0f, 10.0f)]
    public float walk_speed;
    [Range(1.0f, 10.0f)]
    public float backwards_walk_speed;
    [Range(1.0f, 10.0f)]
    public float strafe_speed;
    
    [Range(0.1f, 1.5f)]
    public float rotation_speed;

    [Range(2.0f, 10.0f)]
    // public float jump_force;
    #endregion

    #region Animations
    // private MyTPCharacter tpc;
        private Animator _anim;
    #endregion

    #region SoundWalking
    private bool isWalking;
    private AudioSource _wk;
    #endregion
    private float x,y;

    private void Awake()
    {
        // tpc = FindObjectOfType<MyTPCharacter>();
        _anim = GetComponent<Animator>();
        _cm = GetComponent<CameraMovement>();
        _cam = _cm.GetCamera();
        _rb = GetComponent<Rigidbody>();
        _wk = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Cursor.lockState = CursorLockMode.Locked;
        x=0;
        y=0;
        isWalking = false;
    }

    private void FixedUpdate()
    {
        // Gets the input
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        x=h;
        y=v;
        // jump = Input.GetButtonDown("Jump");

        // Calculate camera relative directions to move:
        camFwd = Vector3.Scale(_cam.transform.forward, new Vector3(1, 1, 1)).normalized;
        Vector3 camFlatFwd = Vector3.Scale(_cam.transform.forward, new Vector3(1, 0, 1)).normalized;
        Vector3 flatRight = new Vector3(_cam.transform.right.x, 0, _cam.transform.right.z);
        
        Vector3 m_CharForward = Vector3.Scale(camFlatFwd, new Vector3(1, 0, 1)).normalized;
        Vector3 m_CharRight = Vector3.Scale(flatRight, new Vector3(1, 0, 1)).normalized;


        // Draws a ray to show the direction the player is aiming at
        Debug.DrawLine(transform.position, transform.position + camFwd * 5f, Color.red);

        // Move the player (movement will be slightly different depending on the camera type)
        float w_speed;
        Vector3 move = Vector3.zero;
        if (_cm.type == CameraMovement.CAMERA_TYPE.FREE_LOOK)
        {
            w_speed = walk_speed;
            move = v * m_CharForward * w_speed + h * m_CharRight * walk_speed;
            _cam.transform.position += move * Time.deltaTime;

            // Rotate body
            transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, move, rotation_speed, 0.0f));
            // tpc.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(tpc.transform.forward, move, rotation_speed, 0.0f));
        }
        else if (_cm.type == CameraMovement.CAMERA_TYPE.LOCKED) {
            w_speed = (v > 0) ? walk_speed : backwards_walk_speed;
            move = v * m_CharForward * w_speed + h * m_CharRight * strafe_speed;
        }

        transform.position += move * Time.deltaTime;    // Move the actual player

        // Jump 
        // if (jump) {
        //     _rb.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerStateMachine();
        SoundWalking();
        // Animations
        _anim.SetFloat("VelX",x);
        _anim.SetFloat("VelY",y);
    }

    void PlayerStateMachine() {


    }

    void SoundWalking()
    {
        if(x!=0 || y!=0)
        {
            if(!isWalking)
            {
                _wk.Play();
                isWalking=true;
            }
        }
        else
        {
            if(isWalking)
            {
                _wk.Stop();
                isWalking=false;
            }
        }   
    }
}
