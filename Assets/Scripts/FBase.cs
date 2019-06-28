using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FBase : MonoBehaviour
{
    [SerializeField] Heart heart = null;
    [SerializeField] int Health = 3;
    [SerializeField] Text ScoreLabel = null;
    [SerializeField] GameObject ScoreUI = null;
    float deltaScore =0;
    int Score = 0;
    public bool Alive = true;
    Queue<Heart> Hearts = new Queue<Heart>();
    public int currHealth;
    // Start is called before the first frame update
    void Start()
    {
        ScoreLabel.text = "0";
        currHealth = Health;
        for(int i = Health; i > 0; i--)
        {
            var pos = new Vector3(40, transform.position.y + (i -1)*12 -5f , transform.position.z + 10f);
            var newHeart = Instantiate(heart, pos, Quaternion.identity);
            Hearts.Enqueue(newHeart);

        }
    }
    public void TakeDamage()
    {
        if (Hearts.Count > 0)
        {
            currHealth--;
            var lostHeart = Hearts.Dequeue();
            var FX = Instantiate(lostHeart.DeathFX, new Vector3(lostHeart.transform.position.x - 6f, lostHeart.transform.position.y + 13f, lostHeart.transform.position.z - 6f), Quaternion.identity);
            Destroy(FX.gameObject, FX.main.duration);
            Destroy(lostHeart.gameObject);
        }
     
    }
    // Update is called once per frame
    void Update()
    {
        if(currHealth == 0)
        {
            Alive = false;
           ScoreUI.SetActive(true);
        }
        if(Alive)
        {
            deltaScore +=  Time.deltaTime;
            if (deltaScore > 1)
            {
                Score += (int)deltaScore * 10;
                deltaScore = 0;
            }
        }
        ScoreLabel.text = Score.ToString();
    }
    public void IncreaseScore()
    {
        Score += 100;
    }
}
