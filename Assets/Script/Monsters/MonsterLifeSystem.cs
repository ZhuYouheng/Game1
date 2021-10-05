using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterLifeSystem : MonoBehaviour
{
    private float life;
    public Sprite hurtImage;
    public Sprite oriImage;
    private float time = 0;
    private bool judgeHurt;

    // Start is called before the first frame update
    void Start()
    {
        life = this.gameObject.GetComponent<MonsterInformation>().life;
    }

    // Update is called once per frame
    void Update()
    {
        if (judgeHurt)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = hurtImage;

            if (time <= 0.2)
            {
                time += Time.deltaTime;
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().sprite = oriImage;
                time = 0;
                judgeHurt = false;
            }
        }

        if (life<=0)
        {
            Destroy(this.gameObject);
        }
    }

    public void HitMonster(float damage)
    {
        this.life -= damage;
        this.gameObject.GetComponent<MonsterInformation>().angry = true;
        judgeHurt = true;
    }
}
