﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.WWZ.WinFormGameEngine
{
    /// <summary>
    /// 游戏对象
    /// </summary>
    public sealed class GameObject
    {
        /// <summary>
        /// 当new一个游戏对象时触发
        /// </summary>
        public static Action<GameObject> OnNewGameObject;

        /// <summary>
        /// 当一个游戏对象被销毁时触发
        /// </summary>
        public static Action<GameObject> OnDestroyGameObject;

        private Transform m_transform;
        private List<BaseComponent> m_componentList = new();
        private List<BaseComponent> m_nextFrameToAdd = new();
        private List<BaseComponent> m_nextFrameToRemove = new();
        private bool m_isDestroyed;
        private string m_name = "GameObject";

        internal List<BaseComponent> ComponentList { get => m_componentList; }

        public Transform Transform
        {
            get
            {
                // 被销毁的游戏对象，就不允许可以访问其Transform了
                if (m_isDestroyed)
                {
                    throw new AlreadyDestroyedException("GameObject has been destroyed but still attempt to access its transform.");
                }
                return m_transform;
            }
        }

        /// <summary>
        /// 是否被标记销毁
        /// </summary>
        public bool IsDestroyed { get => m_isDestroyed; }

        /// <summary>
        /// 游戏对象名称
        /// </summary>
        public string Name { get => m_name; set => m_name = value; }

        internal List<BaseComponent> NextFrameToRemove { get => m_nextFrameToRemove; set => m_nextFrameToRemove = value; }

        public GameObject()
        {
            // 如果引擎尚未开启，抛出异常
            if (!GameSys.Instance.IsUpdating)
            {
                throw new Exception("GameSys is in Exit status, but attempt to new a GameObject.");
            }

            // 注册到GameSys
            GameSys.Instance.NextFrameToAdd.Add(this);

            // 创建Transform对象
            Transform t = new Transform();
            t.GameObject = this;
            m_transform = t;

            GameObject.OnNewGameObject?.Invoke(this);
        }

        public GameObject(string name) : this()
        {
            m_name = name;
        }

        /// <summary>
        /// 添加一个组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public T AddComponent<T>() where T : BaseComponent, new()
        {
            if (m_isDestroyed)
            {
                throw new AlreadyDestroyedException("GameObject has been destroyed but still attempt to add a component to it.");
            }

            T newComponent = new T();
            newComponent.GameObject = this;
            m_nextFrameToAdd.Add(newComponent);
            newComponent.Awake();
            return newComponent;
        }

        /// <summary>
        /// 获取组件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public T GetComponent<T>() where T : BaseComponent
        {
            if (m_isDestroyed)
            {
                throw new AlreadyDestroyedException("GameObject has been destroyed but still attempt to get a component from it.");
            }


            foreach (var each in m_componentList)
            {
                if (each is T && !each.IsDestroyed)
                    return each as T;
            }

            // 遍历nextFrameToAdd查找
            foreach (var each in m_nextFrameToAdd)
            {
                if (each is T && !each.IsDestroyed)
                    return each as T;
            }

            return null;
        }

        /// <summary>
        /// 销毁该游戏对象
        /// </summary>
        public void Destroy()
        {
            if (m_isDestroyed)
            {
                throw new AlreadyDestroyedException("GameObject has been destroyed but still attempt to destroy it again.");
            }

            m_isDestroyed = true;

            GameSys.Instance.NextFrameToRemove.Add(this);

            // 销毁子对象
            foreach (Transform each in m_transform.ChildrenList)
            {
                each.GameObject.Destroy();
            }

            // 销毁每一个组件
            foreach (BaseComponent each in m_componentList)
            {
                each.Destroy();
            }

            foreach (BaseComponent each in m_nextFrameToAdd)
            {
                each.Destroy();
            }

            OnDestroyGameObject?.Invoke(this);
        }

        /// <summary>
        /// 基于名称查找一个游戏对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static GameObject Find(string name)
        {
            return GameSys.Instance.Find(name);
        }

        /// <summary>
        /// 遍历组件，调用Update
        /// </summary>
        internal void UpdateComponent()
        {
            foreach (BaseComponent each in m_nextFrameToAdd)
            {
                m_componentList.Add(each);
            }
            m_nextFrameToAdd.Clear();

            foreach (BaseComponent each in m_nextFrameToRemove)
            {
                m_componentList.Remove(each);
            }
            m_nextFrameToRemove.Clear();

            foreach (BaseComponent eachComp in m_componentList)
            {
                // 如果本对象已经被销毁了，终止遍历
                if (m_isDestroyed)
                    break;

                if (!eachComp.IsStarted)
                {
                    eachComp.Start();
                    eachComp.IsStarted = true;
                }

                eachComp.Update();
            }
        }
    }
}