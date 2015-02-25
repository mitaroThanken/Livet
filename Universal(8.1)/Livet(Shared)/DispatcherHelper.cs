using System;
using System.ComponentModel;
using System.Windows;
using Windows.UI.Core;
using Windows.UI.Xaml;

namespace Livet
{
    /// <summary>
    /// UIDispatcherへのアクセスを簡易化します。
    /// </summary>
    public static class DispatcherHelper
    {
        private static CoreDispatcher _uiDispatcher;

        /// <summary>
        /// UIDispatcherを指定、または取得します。通常このプロパティはApp_StartUpで指定されます。
        /// </summary>
        public static CoreDispatcher UIDispatcher
        {
            get
            {
                if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
                {
                    _uiDispatcher = Window.Current.Dispatcher;
                }
                return _uiDispatcher;
            }
            set
            {
                _uiDispatcher = value;
            }
        }

        /// <summary>
        /// UIDispatcherで指定されたアクションを実行します。
        /// </summary>
        /// <param name="action">アクション</param>
        /// <exception cref="InvalidOperationException">UIDispatcherインスタンスがApp.StartUpなどで確保されていません。</exception>
#if NET45 || NETFX_CORE
        [Obsolete]
#endif
        public static async void BeginInvoke(Action action)
        {
            if (UIDispatcher == null)
            {
                throw new InvalidOperationException("UIDispatcherインスタンスが確保されていません。App.StartUpで確保してください。");
            }

            await UIDispatcher.RunAsync(CoreDispatcherPriority.Normal, () => action());
        }

        /// <summary>
        /// UIDispatcherで指定されたアクションを実行します。
        /// </summary>
        /// <param name="action">アクション</param>
        /// <param name="priority">DispatcherPriority</param>
        /// <exception cref="InvalidOperationException">UIDispatcherインスタンスがApp.StartUpなどで確保されていません。</exception>
#if NET45 || NETFX_CORE
        [Obsolete]
#endif
        public static async void BeginInvoke(Action action, CoreDispatcherPriority priority)
        {
            if (UIDispatcher == null)
            {
                throw new InvalidOperationException("UIDispatcherインスタンスが確保されていません。App.StartUpで確保してください。");
            }

            await UIDispatcher.RunAsync(priority, () => action());
        }
    }
}
