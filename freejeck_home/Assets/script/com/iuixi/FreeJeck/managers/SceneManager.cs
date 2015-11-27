using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

namespace com.iuixi.FreeJeck
{
	public enum SceneEnum 
    {
        LOGIN = 0,
		LOADING,
        USER_INFO,
       // ROOM_LIST,
        GAME_ROOM,
        GAME_RACE
    }

    public interface ISceneLoaer
    {
        void LoadScene();
    }

    public class SceneManager
    {
        private Queue<SceneEnum> m_Scenes;

        public SceneManager()
        {
            m_Scenes = new Queue<SceneEnum>();
        }
        public void PushScene(SceneEnum scene) 
        {
            m_Scenes.Enqueue(scene);
            RenderScene(scene);
        }

        public SceneEnum PopScene()
        {
            SceneEnum scene = SceneEnum.LOGIN;
            if(m_Scenes.Count > 0)
                scene = m_Scenes.Dequeue();
            RenderScene(scene);
            return scene;
        }

        private void RenderScene(SceneEnum scene)
        {
            Application.LoadLevel((int)scene);
        }
		public  AsyncOperation LoadAsyncScene(SceneEnum scene)
		{
			//m_Scenes.Enqueue(scene);
			AsyncOperation	async = Application.LoadLevelAsync((int)scene);
			return async;
		}
	

    }
}
