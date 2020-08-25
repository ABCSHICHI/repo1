﻿using UnityEngine;
using System.Collections;

namespace UICore
{
    //窗体隐藏起来后，所要处理的逻辑
    public delegate void Del_AfterHideUI();
    //窗体类型
    public class UIType
    {
        //显示方式
        public E_ShowUIMode showMode = E_ShowUIMode.HideOther;
        //父节点的类型
        public E_UIRootType uiRootType = E_UIRootType.Normal;
    }
    //UI基类
    //封装窗体共有的行为以及属性
    public class BaseUI : MonoBehaviour
    {
        //窗体类型
        public UIType uiType;
     
        //缓存窗体的RectTransform组件
        protected RectTransform thisTrans;
        //当前窗体的ID
        protected E_UiId uiId = E_UiId.NullUI;
        //上一个窗体的ID
        protected E_UiId beforeUiId = E_UiId.NullUI;

        //获取当前窗体的ID
        public E_UiId GetUiId
        {
            get
            {
                return uiId;
            }
            //为什么没有set?
            //因为每个窗体的ID都是固定的，不能被外界随意修改，外界只能获取它的值
            //只有在子类才能对该窗体的ID进行赋值或修改
            //set
            //{
            //    uiId = value;
            //}
        }
        //上一个窗体Id的属性
        public E_UiId BeforeUiId
        {
            get
            {
                return beforeUiId;
            }
            set
            {
                beforeUiId = value;
            }
        }

        protected virtual void Awake()
        {
            if (uiType ==null)
            {
                uiType = new UIType();
            }
            thisTrans = this.GetComponent<RectTransform>();
            InitUiOnAwake();
            InitDataOnAwake();
        }
        //用于判断窗体显示出来的时候，是否需要去隐藏其他窗体
        public bool IsHideOtherUI()
        {
            if (this.uiType.showMode == E_ShowUIMode.DoNothing)
            {
                return false;//不需要隐藏其他窗体
            }
            else
            {

                //需要去处理隐藏其他窗体的逻辑
                return true;// E_ShowUIMode.HideOther与  E_ShowUIMode.HideAll
            }
        }
        //初始化界面元素
        protected virtual void InitUiOnAwake()
        {
        }
        //初始化数据
        protected virtual void InitDataOnAwake()
        {
        }
        protected virtual void Start()
        {
            InitOnStart();
        }
        //初始化相关逻辑
        protected virtual void InitOnStart()
        {

        }
        //窗体的显示
        public virtual void ShowUI()
        {
            this.gameObject.SetActive(true);
        }
        //窗体额隐藏
        public virtual void HideUI(Del_AfterHideUI del=null)
        {
            this.gameObject.SetActive(false);
            if (del!=null)
            {
                del();
            }
        }
        protected virtual void OnEnable()
        {
            PlayAudio();
        }
        protected virtual void OnDisable()
        {

        }
        //窗体显示出来的时候，播放音效
        protected virtual void PlayAudio()
        {

        }
    }

}
