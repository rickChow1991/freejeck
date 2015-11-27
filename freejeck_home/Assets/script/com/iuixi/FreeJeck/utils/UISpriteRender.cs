using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using LitJson;

namespace com.iuixi.FreeJeck
{
	public class Frame
	{
		public float x, y, w, h;
	}

	public class Size
	{
		public float w, h;
	}

	public class FrameItem
	{
		public string filename;
		public Frame frame;
		public bool rotated;
		public bool trimmed;
		public Frame spriteSourceSize;
		public Size sourceSize;

	}

	public class Meta
	{
		public string app;
		public string version;
		public string image;
		public string format;
		public Size size;
		public string scale;
		public string smartupdate;

	}

	public class FrameAtlas
	{
		public FrameItem[] frames;
		public Meta meta;
	}

	/// <summary>
	/// using raw image to render a sprite with texture packer.
	/// </summary>
	[RequireComponent(typeof(RawImage))]
	public class UISpriteRender : MonoBehaviour
	{
		/// <summary>
		/// Json settings
		/// </summary>
		[SerializeField] private TextAsset m_Text = null;
		/// <summary>
		/// Rate
		/// </summary>
		[SerializeField] private float m_Rate = 60f;
		/// <summary>
		/// is loop mode
		/// </summary>
		[SerializeField] private bool m_Loop = true;

		private RawImage m_Image;
		private uint m_CurrentIndex = 0;
		private bool m_IsPlaying = false;
		private FrameAtlas m_Frames = null;
		private float m_TexWidth;
		private float m_TexHeight;
		private float m_DTime;
		private float m_PastTime;

		// Use this for initialization
		void Start ()
		{
			m_DTime = 1f / m_Rate;
			m_PastTime = m_DTime;
			m_Image = transform.GetComponent<RawImage> ();
			ParseJson ();
			Play ();
		}
	
		// Update is called once per frame
		void Update ()
		{
			if (m_Frames != null &&(m_PastTime -= Time.deltaTime) < 0f) {
				m_PastTime = m_DTime;
				if (m_CurrentIndex >= m_Frames.frames.Length) {
					if (m_Loop) {
						m_CurrentIndex = 0;
					} else {
						return;
					}
				}
				StartCoroutine(RenderFrame (m_CurrentIndex ++));
			}
		}

		private void ParseJson ()
		{
			m_Frames = JsonMapper.ToObject<FrameAtlas>(m_Text.ToString());
			m_TexWidth = m_Frames.meta.size.w;
			m_TexHeight = m_Frames.meta.size.h;
		}

		IEnumerator RenderFrame (uint index)
		{
			yield return null;
			FrameItem item = m_Frames.frames [index];
			m_Image.rectTransform.sizeDelta = new Vector2 (item.sourceSize.w, item.sourceSize.h);
			m_Image.uvRect = new Rect (item.frame.x / m_TexWidth, 1f - (item.frame.y + item.sourceSize.h) / m_TexHeight, item.sourceSize.w / m_TexWidth, item.sourceSize.h / m_TexHeight);
		}

		/// <summary>
		/// Gotos the and play.
		/// </summary>
		public void GotoAndPlay (uint index)
		{
			m_CurrentIndex = Math.Max((uint)m_Frames.frames.Length - 1, index);
			m_IsPlaying = true;
			StartCoroutine(RenderFrame(m_CurrentIndex ++));
		}

		/// <summary>
		/// Gotos the and stop.
		/// </summary>
		public void GotoAndStop (uint index)
		{
			m_CurrentIndex = Math.Max((uint)m_Frames.frames.Length - 1, index);
			m_IsPlaying = false;
			StartCoroutine(RenderFrame(m_CurrentIndex ++));
		}

		/// <summary>
		/// Stop this instance.
		/// </summary>
		public void Stop ()
		{
			m_IsPlaying = false;
		}

		/// <summary>
		/// Play this instance.
		/// </summary>
		public void Play ()
		{
			m_IsPlaying = true;
		}
	}
}
