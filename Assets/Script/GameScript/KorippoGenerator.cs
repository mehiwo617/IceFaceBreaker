using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class KorippoGenerator : MonoBehaviour
{
    public GameObject KorippoPrefab;
    public GameObject EXKorippoPrefab;
    public GameObject UniPrefab;
    public float span = 1.0f;
    public float delta = 0;
    public int ratio = 90;//コオリッポでる確率
    public int color = 15;//色違いの出る確率
    public float banish = 1.5f;
    public bool gen = true;

    public void SetParameter(float span, int ratio,float banish,int color)
    {
        this.span = span;
        this.ratio = ratio;
        this.banish = banish;
        this.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (gen)
        {
            this.delta += Time.deltaTime;
            if(this.delta > this.span)
            {
                float x=0, y=0;

                this.delta = 0;

                /*モグラ生成*/
                int dice = Random.Range(1, 101);
                GameObject po;
                if(dice < ratio)//70%の確率で通常色コオリッポ
                {
                    int dice2 = Random.Range(1, 101);
                    if(dice2 < color)
                    {
                        po = Instantiate(EXKorippoPrefab) as GameObject;//たまに色違いが出る
                        po.GetComponent<KorippoController>().banish = banish;
                    }
                    else
                    {
                        po = Instantiate(KorippoPrefab) as GameObject;
                        po.GetComponent<KorippoController>().banish = banish;
                    }
                }
                else //40％でばちんうに
                {
                    po = Instantiate(UniPrefab) as GameObject;
                    po.GetComponent<UniController>().banish = banish;
                }

                /*モグラ位置決定*/
                int pos_r = Random.Range(1, 10);
                switch (pos_r)
                {
                    case 1:
                        x = -1.8f;
                        y = 2.8f;
                        break;
                    case 2:
                        x = 0;
                        y = 2.8f;
                        break;
                    case 3:
                        x = 1.8f;
                        y = 2.8f;
                        break;
                    case 4:
                        x = -1.8f;
                        y = 0.5f;
                        break;
                    case 5:
                        x = 0;
                        y = 0.5f;
                        break;
                    case 6:
                        x = 1.8f;
                        y = 0.5f;
                        break;
                    case 7:
                        x = -1.8f;
                        y = -2.0f;
                        break;
                    case 8:
                        x = 0;
                        y = -2.0f;
                        break;
                    case 9:
                        x = 1.8f;
                        y = -2.0f;
                        break;
                }
                Vector2 pos = new Vector2(x, y);
                RaycastHit2D hit = Physics2D.Raycast(pos,Vector2.zero);
                if (!hit)
                {
                    po.transform.position = new Vector2(x, y);
                }
                else
                {
                    Destroy(po);
                }
            }
        }
    }

    public void StopGen()
    {
        gen = false;
    }

}
