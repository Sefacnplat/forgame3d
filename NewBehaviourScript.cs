using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody body;

    public GameObject firstlevel;
    public GameObject secondlevel;

    private void Awake ()
    {
        body = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;
        body.velocity = direction * speed;

        if(direction != Vector3.zero) {
            transform.forward = direction;
        }    
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("secondlevel");
        }  
    }
}