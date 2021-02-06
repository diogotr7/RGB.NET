﻿using RGB.NET.Core;

namespace RGB.NET.Devices.Asus
{
    /// <inheritdoc cref="AsusRGBDevice{TDeviceInfo}" />
    /// <summary>
    /// Represents a Asus mainboard.
    /// </summary>
    public class AsusMainboardRGBDevice : AsusRGBDevice<AsusRGBDeviceInfo>, IKeyboard
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RGB.NET.Devices.Asus.AsusMainboardRGBDevice" /> class.
        /// </summary>
        /// <param name="info">The specific information provided by Asus for the mainboard.</param>
        internal AsusMainboardRGBDevice(AsusRGBDeviceInfo info)
            : base(info)
        { }

        #endregion

        #region Methods

        /// <inheritdoc />
        protected override void InitializeLayout()
        {
            int ledCount = DeviceInfo.Device.Lights.Count;
            for (int i = 0; i < ledCount; i++)
                AddLed(LedId.Mainboard1 + i, new Point(i * 40, 0), new Size(40, 8));
        }

        /// <inheritdoc />
        protected override object? GetLedCustomData(LedId ledId) => (int)ledId - (int)LedId.Mainboard1;
        
        #endregion
    }
}
