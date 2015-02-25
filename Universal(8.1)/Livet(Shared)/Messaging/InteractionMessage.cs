﻿using System.Windows;
using Windows.UI.Xaml;

namespace Livet.Messaging
{
    /// <summary>
    /// 相互作用メッセージの基底クラスです。<br/>
    /// Viewからのアクション実行後、戻り値情報が必要ない相互作用メッセージを作成する場合はこのクラスを継承して相互作用メッセージを作成します。
    /// </summary>
    // TODO Freezable を外しても大丈夫？
    // public class InteractionMessage : Freezable
    public class InteractionMessage : DependencyObject
    {
        public InteractionMessage()
        {
        }

        /// <summary>
        /// メッセージキーを指定して新しい相互作用メッセージのインスタンスを生成します。
        /// </summary>
        /// <param name="messageKey">メッセージキー</param>
        public InteractionMessage(string messageKey)
        {
            MessageKey = messageKey;
        }

        /// <summary>
        /// メッセージキーを指定、または取得します。
        /// </summary>
        public string MessageKey
        {
            get { return (string)GetValue(MessageKeyProperty); }
            set { SetValue(MessageKeyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageKey.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageKeyProperty =
            DependencyProperty.Register("MessageKey", typeof(string), typeof(InteractionMessage), new PropertyMetadata(null));
        
        // TODO 外しても大丈夫？
        /*
        /// <summary>
        /// 派生クラスでは必ずオーバーライドしてください。Freezableオブジェクトとして必要な実装です。<br/>
        /// 通常このメソッドは、自身の新しいインスタンスを返すように実装します。
        /// </summary>
        /// <returns>自身の新しいインスタンス</returns>
        protected override Freezable CreateInstanceCore()
        {
            return new InteractionMessage(MessageKey);
        }
         */
    }
}