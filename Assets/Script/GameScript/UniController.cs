using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniController : MonoBehaviour
{
    public GameObject effect;
    GameObject generator;
    GameObject director;
    GameObject sound;

    float delta = 0;
    public float banish = 1.0f;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.sound = GameObject.Find("Audio");
        this.generator = GameObject.Find("KorippoGenerator");
    }

    void Update()
    {
        this.delta += Time.deltaTime;
        if(delta > banish)//消滅時間を超えたら消滅する
        {
            Destroy(gameObject);
        }
    }

    public void Uni_Click()
    {
        this.sound.GetComponent<SE>().Bomb();
        var source = GetComponent<Cinemachine.CinemachineImpulseSource>();
        source.GenerateImpulse();
        GameObject g = Instantiate(effect, transform.position, transform.rotation);
        Destroy(g, 1.0f);

        Destroy(gameObject);
        this.director.GetComponent<GameDirector>().TapUni();
    }

}
