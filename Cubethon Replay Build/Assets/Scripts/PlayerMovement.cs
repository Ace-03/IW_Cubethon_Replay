using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public Rigidbody rb;


    public float fowardforce = 2000f;
    public float sidewaysforce = 100f;

    GameManager manager;

    void Start()
    {
       manager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, fowardforce * Time.deltaTime);

        if (Input.GetKey("d") && !manager.instantReplay)
        {
            //rb.AddForce(sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            //Take inputs and send them to command log
            Command moveRight = new MoveRight(rb, sidewaysforce);
            Invoker invoker = new Invoker();
            invoker.Setcommand(moveRight);
            invoker.ExcuteCommand();
            Debug.Log("Input : Right");
        }

        if (Input.GetKey("a") && !manager.instantReplay)
        {
            //rb.AddForce(-sidewaysforce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
            //Take inputs and send them to command log
            Command moveLeft = new MoveLeft(rb, sidewaysforce);
            Invoker invoker = new Invoker();
            invoker.Setcommand(moveLeft); 
            invoker.ExcuteCommand();
            Debug.Log("Input : Left");
        }

        if (rb.position.y < -2f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
