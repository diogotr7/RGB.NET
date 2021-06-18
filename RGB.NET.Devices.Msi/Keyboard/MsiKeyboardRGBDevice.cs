// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

using RGB.NET.Core;
using RGB.NET.Devices.Msi.Native;

namespace RGB.NET.Devices.Msi
{
    /// <inheritdoc />
    /// <summary>
    /// Represents an MSI keyboard.
    /// </summary>
    public class MsiKeyboardRGBDevice : MsiRGBDevice<MsiRGBDeviceInfo>
    {
        #region Constructors

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:RGB.NET.Devices.Msi.MsiKeyboardRGBDevice" /> class.
        /// </summary>
        /// <param name="info">The specific information provided by MSI for the keyboard.</param>
        internal MsiKeyboardRGBDevice(MsiRGBDeviceInfo info, int ledCount, IDeviceUpdateTrigger updateTrigger)
            : base(info, updateTrigger)
        {
            InitializeLayout(ledCount);
        }

        #endregion

        #region Methods

        private void InitializeLayout(int ledCount)
        {
            for (int i = 0; i < ledCount; i++)
            {
                const string LED_STYLE = "Steady";

                _MsiSDK.SetLedStyle(DeviceInfo.MsiDeviceType, i, LED_STYLE);
                AddLed(LedId.Keyboard_Custom1 + i, new Point(i * 10, 0), new Size(10, 10));
            }
        }

        /// <inheritdoc />
        protected override object? GetLedCustomData(LedId ledId) => (int)ledId - (int)LedId.Keyboard_Custom1;

        #endregion
    }
}