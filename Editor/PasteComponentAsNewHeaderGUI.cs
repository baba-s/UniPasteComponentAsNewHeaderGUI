using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Kogane.Internal
{
	[InitializeOnLoad]
	internal static class PasteComponentAsNewHeaderGUI
	{
		static PasteComponentAsNewHeaderGUI()
		{
			Editor.finishedDefaultHeaderGUI += OnGUI;
		}

		private static void OnGUI( Editor editor )
		{
			var gameObject = editor.target as GameObject;

			// ゲームオブジェクトの Inspector ではない場合は無視
			if ( gameObject == null ) return;

			// プレハブの場合は無視
			if ( string.IsNullOrWhiteSpace( gameObject.scene.path ) ) return;

			if ( GUILayout.Button( "Paste Component As New" ) )
			{
				ComponentUtility.PasteComponentAsNew( gameObject );
			}
		}
	}
}