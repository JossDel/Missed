using UnityEngine;
using System.Collections.Generic;

namespace BlendModes
{
	public struct BlendMaterial
	{
		public Material Material;

		public ObjectType ObjectType;
		public RenderMode RenderMode;
		public BlendMode BlendMode;
		public bool SelectiveBlending;

		public BlendMaterial (ObjectType objectType, RenderMode renderMode, BlendMode blendMode, bool selectiveBlending)
		{
			this.Material = null;
			this.ObjectType = objectType;
			this.RenderMode = renderMode;
			this.BlendMode = blendMode;
			this.SelectiveBlending = selectiveBlending;
		}

		public bool IsEqual (BlendMaterial mat)
		{
			return mat.ObjectType == ObjectType && mat.RenderMode == RenderMode 
				&& mat.BlendMode == BlendMode && mat.SelectiveBlending == SelectiveBlending;
		}
	}

	/// <summary> 
	/// Manages all the materials used for blending and provides caching.
	/// </summary> 
	public static class BlendMaterials
	{
		private static List<BlendMaterial> cachedMaterials = new List<BlendMaterial>();

		/// <summary>
		/// Looks for suitable cached material and creates a new one if needed.
		/// </summary>
		public static Material GetMaterial (ObjectType objectType, RenderMode renderMode, BlendMode blendMode, bool selectiveBlending)
		{
			if (blendMode == BlendMode.Normal)
			{
				if (objectType == ObjectType.MeshDefault)
				{
					var mat = new Material(Shader.Find("Diffuse"));
					mat.hideFlags = HideFlags.HideAndDontSave;
					return mat;
				}
				else if (objectType == ObjectType.SpriteDefault)
				{
					var mat = new Material(Shader.Find("Sprites/Default"));
					mat.hideFlags = HideFlags.HideAndDontSave;
					return mat;
				}
				else if (objectType == ObjectType.ParticleDefault)
				{
					var mat = new Material(Shader.Find("Particles/Additive"));
					mat.hideFlags = HideFlags.HideAndDontSave;
					return mat;
				}
				else return null;
			}

			// Framebuffer won't work in the editor, so fallback to Grab mode.
			if (Application.isEditor && renderMode == RenderMode.Framebuffer) renderMode = RenderMode.Grab;

			var blendMataterial = new BlendMaterial(objectType, renderMode, blendMode, selectiveBlending);

			// Disable caching for mesh and particle materials, as they are sharing them.
			if (objectType != ObjectType.MeshDefault && objectType != ObjectType.ParticleDefault && cachedMaterials.Exists(m => m.IsEqual(blendMataterial)))
				return cachedMaterials.Find(m => m.IsEqual(blendMataterial)).Material;
			else
			{
				var mat = new Material(Resources.Load<Shader>(string.Format("BlendModes/{0}/{1}", objectType, renderMode)));
				mat.hideFlags = HideFlags.HideAndDontSave;
				mat.EnableKeyword("BM" + blendMode.ToString());
				mat.SetFloat("_IsSelectiveBlendingActive", selectiveBlending ? 1 : 0);

				blendMataterial.Material = mat;

				cachedMaterials.Add(blendMataterial);

				return mat;
			}
		}
	}
}
