using UnityEngine;

public class SceneEndingController : MonoBehaviour
{
    [SerializeField] GameObject Boss;
    [SerializeField] float BossEndPosition;
    [SerializeField] GameObject DarkSingularity;
    [SerializeField] GameObject Player;
    [SerializeField] bool isBossFightStarted = false;
    [SerializeField] float DarkSingularitySpeed = 1f;
    [SerializeField] float BossSpeed = 1f;

    void Update()
    {
        if (isBossFightStarted && Boss.transform.position.y <= BossEndPosition)
        {
            Boss.transform.position += Vector3.up * Time.deltaTime * BossSpeed;
        }
        if (isBossFightStarted && Boss.transform.position.y >= BossEndPosition)
        {
            DarkSingularity.transform.position = transform.position = Vector3.MoveTowards(DarkSingularity.transform.position, Player.transform.position, Time.deltaTime * DarkSingularitySpeed);
            DarkSingularity.transform.localScale += Vector3.one * Time.deltaTime / 2;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player"){
            isBossFightStarted = true;
        }
    }
}
