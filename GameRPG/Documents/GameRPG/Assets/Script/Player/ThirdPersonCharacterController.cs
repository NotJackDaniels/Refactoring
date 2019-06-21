using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ThirdPersonCharacterController : MonoBehaviour
{
    public float Speed;
    public float speedRun;
    public float enerjyForRun;
    public AudioSource sourse;
    public AudioClip clip;


    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        sourse.playOnAwake = false;
        sourse.loop = true;
        sourse.clip = clip; 
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (Input.GetKey(KeyCode.LeftShift) && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)) && GameObject.FindGameObjectWithTag("Player").GetComponent<playerstat>().curMP > enerjyForRun)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<playerstat>().curMP -= enerjyForRun;

            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver).normalized * speedRun * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);   
            if (!sourse.isPlaying)
            {
                sourse.Play();
            }
        }
        else
        {
            float hor = Input.GetAxis("Horizontal");
            float ver = Input.GetAxis("Vertical");
            Vector3 playerMovement = new Vector3(hor, 0f, ver).normalized * Speed * Time.deltaTime;
            transform.Translate(playerMovement, Space.Self);
            if (!sourse.isPlaying)
            {
                sourse.Play();
            }
        }
        if (!(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S)))
        {
            sourse.Stop();
        }

       
    }
}
