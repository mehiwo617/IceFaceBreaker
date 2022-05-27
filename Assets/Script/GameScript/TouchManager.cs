using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchManager
{
    public bool _touch_frag;
    public Vector2 _touch_position;
    public TouchPhase _touch_phase;

    public TouchManager(bool flag = false, Vector2? position = null, TouchPhase phase = TouchPhase.Began)
    {
        this._touch_frag = flag;
        if (position == null)
        {
            this._touch_position = new Vector2(0, 0);
        }
        else
        {
            this._touch_position = (Vector2)position;
        }
        this._touch_phase = phase;
    }

    public void update()
    {
        this._touch_frag = false;

        if (Application.isEditor)
        {

            if (Input.GetMouseButtonUp(0))
            {
                this._touch_frag = true;
                this._touch_phase = TouchPhase.Ended;
                //Debug.Log("話した瞬間");
            }

            if (this._touch_frag)
            {
                this._touch_position = Input.mousePosition;
            }
        }
        else
        {
            //if(Input.touchCount > 0)
            //{
            //    Touch touch = Input.GetTouch(0);
            //    this._touch_position = touch.position;
            //    this._touch_phase = touch.phase;
            //    if (touch.phase == TouchPhase.Ended)
            //    {
            //        // タッチ終了
            //        this._touch_frag = true;
            //    }
            //}
            //else
            //{

                if (Input.GetMouseButtonDown(0))
                {
                    this._touch_frag = true;
                    this._touch_phase = TouchPhase.Ended;
                    //Debug.Log("話した瞬間");
                }

                if (this._touch_frag)
                {
                    this._touch_position = Input.mousePosition;
                }
            //}
        }
    }

    public TouchManager GetTouch()
    {
        return new TouchManager(this._touch_frag, this._touch_position, this._touch_phase);
    }
   
}
