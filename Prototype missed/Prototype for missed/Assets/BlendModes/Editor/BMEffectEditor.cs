using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using System.Collections.Generic;

namespace BlendModes
{
	[InitializeOnLoad, CustomEditor(typeof(BlendModeEffect)), CanEditMultipleObjects]
	public class BMEffectEditor : Editor
	{
		private bool showEditor, showRenderMode, showSelectiveBlending, showMaterialParams, showFramebufferInfo, showUnityProWarning;

		private GUIContent blendModeContent = new GUIContent("Blend Mode", "Blend mode of the object.");
		private GUIContent renderModeContent = new GUIContent("Render Mode",
			"Render mode to use for blending.\n\nGrab will execute a grab pass for each object with blend mode effect per frame, which may cause a significant performance drop when using with lots of objects simultaneously.\n\nUnified Grab will use a shared grab texture and perform only one grab pass per frame for all the objects in this mode, which will yield a much better performance when using multiple instances of the effect. The only drawback is that objects in Unified Grab mode won't blend with each other.\n\nFramebuffer will not use a grab pass at all, which is extremely faster and will work smoothly on mobile devices. The device has to support framebuffer_fetch extension for this to work. Consult the documentation for more info.");
		private GUIContent selectiveBlendingContent = new GUIContent("Selective Blending", "While selective blending is active the object will use custom blending only with other objects in this mode and keep normal blend mode with everything else. Only Grab and Framebuffer render modes support this.\n\nThe feature is considered experimental - use with care.");
		private GUIContent meshTextureContent = new GUIContent("Texture", "Texture of the object.");
		private GUIContent meshTintColorContent = new GUIContent("Tint Color", "Tint color of the object.");

		private SerializedProperty blendMode;
		private SerializedProperty renderMode;
		private SerializedProperty selectiveBlending;
		private SerializedProperty texture;
		private SerializedProperty tintColor;

		private static Dictionary<GameObject, bool> affectedObjects = new Dictionary<GameObject, bool>();

		static BMEffectEditor ()
		{
			EditorApplication.update += Update;
		}

		// Hack to control prefab objects material when adding/removing BlendModeEffect component. 
		// If only prefabs would fire OnEnable/Disable events...
		static void Update ()
		{
			foreach (var selectedGO in Selection.gameObjects)
			{
				if (PrefabUtility.GetPrefabType(selectedGO) != PrefabType.Prefab) continue;

				var blendEffect = selectedGO.GetComponent<BlendModeEffect>();
				if (!blendEffect)
				{
					// User removed BlendModeEffect.
					if (affectedObjects.ContainsKey(selectedGO))
					{
						var tempBE = selectedGO.AddComponent<BlendModeEffect>();
						tempBE.OnEnable();
						tempBE.OnDisable();
						DestroyImmediate(tempBE, true);
						affectedObjects.Remove(selectedGO);
						EditorUtility.SetDirty(selectedGO);
					}
					continue;
				}
				else
				{
					// First launch or user added BlendModeEffect.
					if (!affectedObjects.ContainsKey(selectedGO))
					{
						blendEffect.OnEnable();
						affectedObjects.Add(selectedGO, true);
						EditorUtility.SetDirty(selectedGO);
					}

					// User enabled/disabled BlendModeEffect.
					if (affectedObjects[selectedGO] != blendEffect.enabled)
					{
						if (blendEffect.enabled) blendEffect.OnEnable();
						else blendEffect.OnDisable();
						affectedObjects[selectedGO] = blendEffect.enabled;
						EditorUtility.SetDirty(selectedGO);
					}
				}
			}
		}

		private void OnEnable ()
		{
			blendMode = serializedObject.FindProperty("_blendMode");
			renderMode = serializedObject.FindProperty("_renderMode");
			selectiveBlending = serializedObject.FindProperty("_selectiveBlending");
			texture = serializedObject.FindProperty("_texture");
			tintColor = serializedObject.FindProperty("_tintColor");

			Undo.undoRedoPerformed += SyncParameters;
		}

		private void OnDisable ()
		{
			Undo.undoRedoPerformed -= SyncParameters;
		}

		public override void OnInspectorGUI ()
		{
			if (!Selection.activeGameObject) return;

			var blendEffect = Selection.activeGameObject.GetComponent<BlendModeEffect>();
			if (!blendEffect) return;

			if (Event.current.type == EventType.Layout)
			{
				showEditor = blendEffect.ObjectType != ObjectType.Unknown;
				showRenderMode = blendEffect.BlendMode != BlendMode.Normal;
				showSelectiveBlending = false;//blendEffect.BlendMode != BlendMode.Normal && blendEffect.RenderMode != RenderMode.UnifiedGrab;
				showMaterialParams = blendEffect.ObjectType == ObjectType.MeshDefault || 
					blendEffect.ObjectType == ObjectType.ParticleDefault;
				showFramebufferInfo = blendEffect.RenderMode == RenderMode.Framebuffer;
				showUnityProWarning = ShowUnityProWarning();
			}

			if (showEditor)
			{
				serializedObject.Update();

				EditorGUILayout.Space();
				EditorGUILayout.PropertyField(blendMode, blendModeContent);
				EditorGUILayout.BeginHorizontal();
				GUILayout.Space(EditorGUIUtility.labelWidth);
				if (GUILayout.Button("<< previous", EditorStyles.miniButton, GUILayout.MinWidth(80)))
				{
					int blendModeIndex = blendMode.enumValueIndex;
					blendModeIndex--;
					if (blendModeIndex < 0)
						blendModeIndex = System.Enum.GetNames(typeof(BlendMode)).Length - 1;
					blendMode.enumValueIndex = blendModeIndex;
				}
				if (GUILayout.Button("next >>", EditorStyles.miniButton, GUILayout.MinWidth(80)))
				{
					int blendModeIndex = blendMode.enumValueIndex;
					blendModeIndex++;
					if (blendModeIndex >= System.Enum.GetNames(typeof(BlendMode)).Length)
						blendModeIndex = 0;
					blendMode.enumValueIndex = blendModeIndex;
				}
				EditorGUILayout.EndHorizontal();
				EditorGUILayout.Space();

				if (showRenderMode) EditorGUILayout.PropertyField(renderMode, renderModeContent);

				if (showSelectiveBlending) EditorGUILayout.PropertyField(selectiveBlending, selectiveBlendingContent);

				if (showMaterialParams)
				{
					EditorGUILayout.PropertyField(texture, meshTextureContent);
					EditorGUILayout.PropertyField(tintColor, meshTintColorContent);
				}

				serializedObject.ApplyModifiedProperties();

				if (GUI.changed) SyncParameters();

				if (showFramebufferInfo) 
					EditorGUILayout.HelpBox("Framebuffer mode will be active on mobile devices with framebuffer_fetch extension support. While in editor, Grab mode will be used for preview.", MessageType.Info);

				if (showUnityProWarning)
					EditorGUILayout.HelpBox("Grab and Unified Grab modes require Unity 4 Pro license to work correctly.", MessageType.Warning);
			}
			else EditorGUILayout.HelpBox("Can't find a compatible renderer component to apply blend mode effect.", MessageType.Warning);
		}

		private void SyncParameters ()
		{
			foreach (var selectedGO in Selection.gameObjects)
			{
				var blendEffect = selectedGO.GetComponent<BlendModeEffect>();
				if (!blendEffect) continue;

				blendEffect.SetBlendMode(blendEffect.BlendMode, blendEffect.RenderMode, blendEffect.SelectiveBlending);
				EditorUtility.SetDirty(selectedGO);
			}
		}

		private bool ShowUnityProWarning ()
		{
			if (Application.unityVersion[0] != '4') return false;

			if (!Application.HasProLicense()) return true;

			#if UNITY_IOS 
			if (!InternalEditorUtility.GetLicenseInfo().Contains("iPhone Pro")) return true;
			#endif

			#if UNITY_ANDROID
			if (!InternalEditorUtility.GetLicenseInfo().Contains("Android Pro")) return true;
			#endif

			return false;
		}
	}
}
