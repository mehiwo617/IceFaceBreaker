using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]

public class KorippoController : MonoBehaviour
{
    public GameObject effect;
    GameObject director;
    GameObject sound;
    Animator animator;
    AnimatorStateInfo currentState;

    float delta = 0;
    public float banish = 1.5f;

    public int tapcount = 0;

    void Start()
    {
        this.director = GameObject.Find("GameDirector");
        this.sound = GameObject.Find("Audio");
        this.animator = GetComponent<Animator>();
    }

    void Update()
    {
        this.delta += Time.deltaTime;

        if (delta > banish / 2.0f)//消滅時間を超えたら消滅する
        {
            animator.SetBool("jump", true);
            this.gameObject.transform.localScale += new Vector3(0.01f, 0.01f, 0);
            if(delta > banish)
            {
                this.director.GetComponent<GameDirector>().Korippo_Crush();
                this.sound.GetComponent<SE>().Bomb();

                Destroy(gameObject);
            }
        }
    }

    public void Korippo_Click()
    {
        this.sound.GetComponent<SE>().Pikon();
        GameObject g = Instantiate(effect,transform.position,transform.rotation);
        Destroy(g, 1.0f);

        if(tapcount == 0)//1回目のタップなら変更
        {
            animator.SetBool("tap", true);
            tapcount++;
            banish += 1.0f;

            this.director.GetComponent<GameDirector>().BrakeIce();
        }else if(tapcount == 1)//2回目なら消滅
        {
            Destroy(gameObject);
            this.director.GetComponent<GameDirector>().BrakeNice();
        }
    }

    public void KorippoEX_Click()
    {
        this.sound.GetComponent<SE>().Kiran();
        GameObject g = Instantiate(effect, transform.position, transform.rotation);
        Destroy(g, 1.0f);

        if (tapcount == 0)//1回目のタップなら変更
        {
            animator.SetBool("tap", true);
            tapcount++;
            banish += 1.0f;

            this.director.GetComponent<GameDirector>().BrakeIceEX();
        }
        else if (tapcount == 1)//2回目なら消滅
        {
            Destroy(gameObject);
            this.director.GetComponent<GameDirector>().BrakeNiceEX();
        }
    }
}
