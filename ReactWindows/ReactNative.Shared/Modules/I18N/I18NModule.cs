// Copyright (c) Microsoft Corporation. All rights reserved.
// Portions derived from React Native:
// Copyright (c) 2015-present, Facebook, Inc.
// Licensed under the MIT License.

using Newtonsoft.Json.Linq;
using ReactNative.Bridge;
using System.Globalization;

namespace ReactNative.Modules.I18N
{
    /// <summary>
    /// A module that allows JS to get/set right to left preferences.
    /// </summary>
    class I18NModule : NativeModuleBase
    {
        private const string ModuleName = "I18nManager";
        private const string IsRtl = "isRTL";
        private const string LocalIdentifier = "localeIdentifier";

        /// <summary>
        /// Gets the module name.
        /// </summary>
        public override string Name
        {
            get
            {
                return ModuleName;
            }
        }

        /// <summary>
        /// The constants exported by this module.
        /// </summary>
        public override JObject ModuleConstants
        {
            get
            {
                return new JObject
                {
                    { IsRtl, I18NUtil.IsRightToLeft },
                    { LocalIdentifier, CultureInfo.CurrentCulture.Name }
                };
            }
        }

        /// <summary>
        /// Sets whether to allow right to left.
        /// </summary>
        /// <param name="value">true to allow right to left; else false.</param>
        [ReactMethod]
        public void allowRTL(bool value)
        {
            I18NUtil.IsRightToLeftAllowed = value;
        }

        /// <summary>
        /// Sets whether to force right to left.  This is used for development purposes to force a language such as English to be RTL.
        /// </summary>
        /// <param name="value">true to force right to left; else false.</param>
        [ReactMethod]
        public void forceRTL(bool value)
        {
            I18NUtil.IsRightToLeftForced = value;
        }
    }
}
