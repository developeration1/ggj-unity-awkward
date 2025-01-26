using AT7.Utils;
using UnityEngine;

public class ColorManager : Singleton<ColorManager>
{
    [SerializeField] GameColorPalette palette;

    public GameColorPalette Palette => palette;
}
