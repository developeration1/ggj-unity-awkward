// Copyright (c) 2015 - 2023 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

//.........................
//.....Generated Class.....
//.........................
//.......Do not edit.......
//.........................

using System.Collections.Generic;
// ReSharper disable All
namespace Doozy.Runtime.UIManager.Containers
{
    public partial class UIView
    {
        public static IEnumerable<UIView> GetViews(UIViewId.Game id) => GetViews(nameof(UIViewId.Game), id.ToString());
        public static void Show(UIViewId.Game id, bool instant = false) => Show(nameof(UIViewId.Game), id.ToString(), instant);
        public static void Hide(UIViewId.Game id, bool instant = false) => Hide(nameof(UIViewId.Game), id.ToString(), instant);

        public static IEnumerable<UIView> GetViews(UIViewId.Menu id) => GetViews(nameof(UIViewId.Menu), id.ToString());
        public static void Show(UIViewId.Menu id, bool instant = false) => Show(nameof(UIViewId.Menu), id.ToString(), instant);
        public static void Hide(UIViewId.Menu id, bool instant = false) => Hide(nameof(UIViewId.Menu), id.ToString(), instant);
    }
}

namespace Doozy.Runtime.UIManager
{
    public partial class UIViewId
    {
        public enum Game
        {
            HandShake
        }

        public enum Menu
        {
            Main,
            OnePlayerCharacterSelect,
            OnePlayerSync,
            TwoPlayerCharacterSelect,
            TwoPlayerSync
        }    
    }
}
