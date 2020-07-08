﻿using BarRaider.SdTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soundpad.Actions
{
    [PluginActionId("com.barraider.soundpadpause")]
    public class SoundpadPauseToggleAction : PluginBase
    {
        public SoundpadPauseToggleAction(SDConnection connection, InitialPayload payload) : base(connection, payload)
        {
            SoundpadManager.Instance.Connect();
        }

        public override void Dispose() { }

        public override void KeyPressed(KeyPayload payload)
        {
            SoundpadManager.Instance.TogglePause();
        }

        public override void KeyReleased(KeyPayload payload) { }

        public override void OnTick()
        {
            if (!SoundpadManager.Instance.IsConnected)
            {
                Connection.SetImageAsync(Properties.Settings.Default.SoundPadNotRunning);
                return;
            }

            Connection.SetImageAsync((string)null);
        }

        public override void ReceivedGlobalSettings(ReceivedGlobalSettingsPayload payload) { }

        public override void ReceivedSettings(ReceivedSettingsPayload payload) { }
    }
}
