// ------------------------------------------------------------------------------
//	This code was edit by Emacs.
//	author : albin
//	created at : Thu May  7 20:35:21 2015
//  	Copyright (c) icee.cn
// ------------------------------------------------------------------------------

using System;
using System.Collections;
using UnityEngine;

namespace com.iuixi.FreeJeck{
    /// <summary>
    /// ClassName:TableCell
    /// Date:Thu May  7 20:35:31 2015
    /// Author: albin
    /// Description: Edit by Emacs
    /// </summary>
    public class TableCell<T> : MonoBehaviour {

        /// <summary>
        /// Standard Start
        /// </summary>
        void Start() {
            
        }
        
        /// <summary>
        /// Standart update
        void Updtae() {
            
        }

		public virtual float GetWidth(){return 0f;}
		public virtual float GetHeight(){return 0f;}
		public virtual void Render(T data)
		{

		}
    }

}
