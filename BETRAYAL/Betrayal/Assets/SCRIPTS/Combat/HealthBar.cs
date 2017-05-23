using UnityEngine;

namespace Assets.SCRIPTS.Combat
{
    public class HealthBar : MonoBehaviour {

        GUIStyle _healthStyle;
        GUIStyle _backStyle;
        CombatScript _combat;

        void Awake()
        {
            _combat = GetComponent<CombatScript>();
        }

        void OnGUI()
        {
            InitStyles();

            // Draw a Health Bar

            Vector3 pos = UnityEngine.Camera.main.WorldToScreenPoint(transform.position);

            // draw health bar background
            GUI.color = Color.grey;
            GUI.backgroundColor = Color.grey;
            GUI.Box(new Rect(pos.x - 26, Screen.height - pos.y + 20, CombatScript.MaxHealth / 2, 7), ".", _backStyle);

            // draw health bar amount
            GUI.color = Color.green;
            GUI.backgroundColor = Color.green;
            GUI.Box(new Rect(pos.x - 25, Screen.height - pos.y + 21, _combat.Health / 2, 5), ".", _healthStyle);
        }

        void InitStyles()
        {
            if (_healthStyle == null)
            {
                _healthStyle = new GUIStyle(GUI.skin.box);
                _healthStyle.normal.background = MakeTex(2, 2, new Color(0f, 1f, 0f, 1.0f));
            }

            if (_backStyle == null)
            {
                _backStyle = new GUIStyle(GUI.skin.box);
                _backStyle.normal.background = MakeTex(2, 2, new Color(0f, 0f, 0f, 1.0f));
            }
        }

        Texture2D MakeTex(int width, int height, Color col)
        {
            Color[] pix = new Color[width * height];
            for (int i = 0; i < pix.Length; ++i)
            {
                pix[i] = col;
            }
            Texture2D result = new Texture2D(width, height);
            result.SetPixels(pix);
            result.Apply();
            return result;
        }
    }
}
