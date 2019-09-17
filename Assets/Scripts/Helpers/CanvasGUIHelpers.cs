using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Helpers
{
    public class CanvasGUIHelpers
    {
        public static Text GetTextByName(Transform parent, string name)
        {
            Transform child = parent.Find(name);
            return child.GetComponent<Text>();
        }
        public static  Image GetImageByName(Transform parent, string name)
        {
            Transform child = parent.Find(name);
            return child.GetComponent<Image>();
        }
    }
}
