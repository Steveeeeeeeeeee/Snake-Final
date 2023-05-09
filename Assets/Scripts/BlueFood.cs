using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFood : Food



{
    [SerializeField]
    public float minSpawnInterval;
    [SerializeField]
    public float maxSpawnInterval;
    public float specialPowerDuration = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player || other.gameObject == segment)
        {
            GameObject.Find("Blue food").transform.position = new Vector2(100,40); // move the food off screen 
            StartCoroutine(ApplySpecialPower());
               
        }
    }

    private IEnumerator ApplySpecialPower()
{
    Player playerMovement = player.GetComponent<Player>();
    float originalSpeed = playerMovement.speed;

    playerMovement.speed *= 2;

    yield return new WaitForSeconds(specialPowerDuration);
    StartCoroutine(RandomWait());
    playerMovement.speed = originalSpeed;
}
    private IEnumerator RandomWait()
    {
        yield return new WaitForSecondsRealtime(Random.Range(minSpawnInterval, maxSpawnInterval));
        RandomPosition();   
    }

}
